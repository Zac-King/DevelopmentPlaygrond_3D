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
    private bool isExpiring;
    public bool IsExpiring      // read-write   // Instance property
    {
        get
        {   return isExpiring;  }

        set
        {
            if (value != isExpiring)
            {
                isExpiring = value;

                if (isExpiring)
                    StartCoroutine("ExpirtionCountDown");
                else
                    StopCoroutine("ExpirtionCountDown");
            }
        }
    }

    [SerializeField] private float lifeTime = 0;
    public float LifeTime       // read only    // Instance property
    {
        get
        { return lifeTime; }
    }

    [SerializeField] private float elapsedTime = 0;     // Only for Editor
    public IEnumerator ExpirtionCountDown()
    {
        float timer = 0;

        while (timer <= LifeTime)
        {
            timer += Time.deltaTime;
            elapsedTime = timer;
            yield return null;
        }
        
        OnExpire();
    }

    public void OnExpire()
    {
        Debug.Log(gameObject.name + " Expired");
        Destroy(gameObject);
    }
    // IPickUp /////////////////////////////////////////////////////////////////////////////////////////
    public void OnCollected()
    {
        throw new NotImplementedException();
    }

    public void OnPull()
    {
        throw new NotImplementedException();
    }
}
