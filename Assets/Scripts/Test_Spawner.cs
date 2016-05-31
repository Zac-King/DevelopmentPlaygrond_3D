using UnityEngine;
using System.Collections;

public class Test_Spawner : MonoBehaviour
{
    public GameObject emission;
    public float spawnDelay = 0;
    private float elapsedTime = 0;
	
    void Update()
    {
        if(elapsedTime > spawnDelay)
        {
            elapsedTime = 0;
            GameObject o = Instantiate(emission);
            o.transform.position = gameObject.transform.position;
            o.transform.parent = null;
            //o.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0));
        }
        elapsedTime += Time.deltaTime;
    }
}
