using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class EnemyController : NetworkBehaviour {

    public int speed = 10;
    public NavMeshAgent agent;

    private bool canMove = true;
    [SyncVar]
    public bool alive = true;

	void Start () {
        agent = gameObject.GetComponent<NavMeshAgent>();
	}

    void Update()
    {
        if (!alive)
            gameObject.SetActive(false);
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Bullet") {
            //gameObject.SetActive (false);
            //gameObject.GetComponent<NavMeshAgent> ().enabled = false;
            //Destroy(agent);
            //Destroy(gameObject.GetComponent<MeshRenderer>());
            //Destroy(gameObject.GetComponent<BoxCollider>());
            canMove = false;
            alive = false;
			other.gameObject.SetActive (false);
        }
	}

    public void moveTo(Transform transform)
    {
        if(canMove)
            agent.destination = transform.position;
    }

//	void OnTriggerEnter(Collider other)
//	{
//		if (other.gameObject.tag == "Player") {
	//		transform.Translate (other.transform.position * speed * Time.deltaTime);
//			transform.position = Vector3.MoveTowards(transform.position, other.transform.position, speed);
//		}
//	}

//	void OnTriggerExit(Collider other)
//	{
	//	if (other.gameObject.tag == "Player") {
//			transform.Translate (transform.position * 0);
//		}
//	}
}
