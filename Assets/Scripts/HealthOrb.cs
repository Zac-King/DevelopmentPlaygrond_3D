using UnityEngine;
using System.Collections;
using System;

public class HealthOrb : MonoBehaviour, IPickUp, IExpirable
{
    void Awake()
    {
        IsExpiring = true;
    }
    // IExpirable Implementation ///////////////////////////////////////////////////////////////////////
    private bool m_isExpiring;  // private member variable  // Accessable through 'IsExpiring' Instance property
    public bool IsExpiring      // read-write       // Instance property
    {
        get
        {   return m_isExpiring;  }

        set
        {
            if (value != m_isExpiring)
            {
                m_isExpiring = value;

                if (m_isExpiring)
                    StartCoroutine("ExpirtionCountDown");
                else
                    StopCoroutine("ExpirtionCountDown");
            }
        }
    }

    [SerializeField] private float m_lifeTime = 0;  // private member variable  // Accessable through 'LifeTime' Instance property
    public float LifeTime       // read only        // Instance property
    {
        get
        { return m_lifeTime; }
    }

    [SerializeField] private float elapsedTime = 0; // Only for Editor  // Used to visualize elapsed time when debugging
    public IEnumerator ExpirtionCountDown() // 
    {
        float timer = 0;    // 

        while (timer <= LifeTime)
        {
            timer += Time.deltaTime;
            elapsedTime = timer;
            yield return null;
        }

        //OnExpire();
        gameObject.GetComponent<Animation>().Play();    // Last frame of animation calls OnExpire()
    }

    public void OnExpire()
    {
        //Debug.Log(gameObject.name + " Expired");
        Destroy(gameObject);
    }
    // IPickUp Implementation //////////////////////////////////////////////////////////////////////////
    private bool available = true;

    public void OnCollected()               // 
    {
        StopCoroutine(Vacuum());// 
        // The cool stuff here 
        Debug.Log(gameObject.name + " collected");
        Destroy(gameObject.transform.parent.gameObject);
        Destroy(gameObject);    // 
    }

    public void OnPull(GameObject Puller)   // When object is 
    {
        if(available)
        {
            available = false;
            IsExpiring = false;

            GameObject animParent = Instantiate(Resources.Load("IPickUp_AnimationParent") as GameObject);
            animParent.transform.position = Puller.transform.position;
            animParent.transform.parent = Puller.transform;
            gameObject.transform.parent = animParent.transform;

            StartCoroutine(Vacuum());
        }
    }

    private IEnumerator Vacuum()            // 
    {
        while(Vector3.Distance(gameObject.transform.position, gameObject.transform.parent.transform.position) > 0.5f)
        {
            gameObject.transform.position += (gameObject.transform.parent.position - gameObject.transform.position) * 2 * Time.deltaTime;
            yield return null;
        }
        OnCollected();
    }
}
