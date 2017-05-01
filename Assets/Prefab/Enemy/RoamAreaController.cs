using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

// http://answers.unity3d.com/questions/605572/random-spawn-locations-1.html


public class RoamAreaController : MonoBehaviour {
    //public NavMeshAgent agent;
    //public NavMeshAgent agent2;
    //public NavMeshAgent agent3;
    public GameObject enemy;

    public float x, x1, x2;
    public float y, y1, y2;
    public float z, z1, z2;

    public GameObject e1, e2, e3;

    // Use this for initialization
    void Start () {
        //agent = agent.GetComponent<NavMeshAgent>();
        //agent2 = agent2.GetComponent<NavMeshAgent>();
        //agent3 = agent3.GetComponent<NavMeshAgent>();
     
       spawn();
	}

    public void spawn()
    {
        x = 8;
        y = Random.Range(MinY, MaxY);
        z = 12;

        x1 = -32;
        y1 = Random.Range(MinY, MaxY);
        z1 = 0;

        x2 = -17;
        y2 = Random.Range(MinY, MaxY);
        z2 = 24;

        spawnObject();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //gameobject for spawning 
    //public GameObject spawnObj;
    //set custom range for random position
    public float MinX = -40;
    public float MaxX = 40;
    public float MinY = 0;
    public float MaxY = 10;

    //for 3d you have z position
    public float MinZ = -40;
    public float MaxZ = 40;


    public void spawnObject()
    {
     
        Vector3 v3 = new Vector3(gameObject.transform.position.x, -0.162f, gameObject.transform.position.z);

            
        e1 = Instantiate(enemy, v3, Quaternion.identity);
        e1.transform.SetParent(gameObject.transform, false);
        e1.transform.localPosition = new Vector3(x, -0.162f, z);

        //e1.transform.localPosition = new Vector3(x, -0.162f, z);
        //e1 = Instantiate(enemy, new Vector3(x, 0.5f, z), Quaternion.identity, gameObject.transform);
        //agent.transform.localPosition = new Vector3(x, 0.5f, z);

        e2 = Instantiate(enemy, v3, Quaternion.identity);
        e2.transform.SetParent(gameObject.transform, false);
        e2.transform.localPosition = new Vector3(x1, -0.162f, z1);

        //e1 = Instantiate(enemy, v3, Quaternion.identity);
        //e1.transform.SetParent(gameObject.transform, false);

        //e2.transform.localPosition = new Vector3(x, -0.162f, z);
        //e2 = Instantiate(enemy, new Vector3(x, 0.5f, z), Quaternion.identity, gameObject.transform);
        //agent2.transform.localPosition = new Vector3(x, 0.5f, z);

        e3 = Instantiate(enemy, v3, Quaternion.identity);
        e3.transform.SetParent(gameObject.transform, false);
        e3.transform.localPosition = new Vector3(x2, -0.162f, z2);

        //e3 = Instantiate(enemy, gameObject.transform);
        //e3.transform.localPosition = new Vector3(x, -0.162f, z);
        //e3 = Instantiate(enemy, new Vector3(x, 0.5f, z), Quaternion.identity, gameObject.transform);
        //agent3.transform.localPosition = new Vector3(x, 0.5f, z);

        

    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            e1.GetComponent<EnemyController>().moveTo(other.transform);
            e2.GetComponent<EnemyController>().moveTo(other.transform);
            e3.GetComponent<EnemyController>().moveTo(other.transform);


            //if(e1.GetComponent<NavMeshAgent>().enabled)
            //             e1.GetComponent<NavMeshAgent>().destination = other.transform.position;
            //if(e2.GetComponent<NavMeshAgent>().enabled)
            //             e2.GetComponent<NavMeshAgent>().destination = other.transform.position;
            //if(e3.GetComponent<NavMeshAgent>().enabled)
            //             e3.GetComponent<NavMeshAgent>().destination = other.transform.position;
        }
    }

    //void OnTriggerEnd(Collider other)
    //{
    //    if(other.tag == "Player")
    //    {
    //        float x = Random.Range(MinX, MaxX);
    //        float y = Random.Range(MinY, MaxY);
    //        float z = Random.Range(MinZ, MaxZ);

    //        agent.transform.localPosition = new Vector3(x, 0.5f, z);

    //        x = Random.Range(MinX, MaxX);
    //        y = Random.Range(MinY, MaxY);
    //        z = Random.Range(MinZ, MaxZ);

    //        agent2.transform.localPosition = new Vector3(x, 0.5f, z);

    //        x = Random.Range(MinX, MaxX);
    //        y = Random.Range(MinY, MaxY);
    //        z = Random.Range(MinZ, MaxZ);

    //        agent3.transform.localPosition = new Vector3(x, 0.5f, z);
    //    }
    //}
}
