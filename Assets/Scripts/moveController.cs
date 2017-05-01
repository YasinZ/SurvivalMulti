using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class moveController : NetworkBehaviour {
	
	public int speed = 50;
	public int offSet = 10;
	[SyncVar]
	public int health = 100;
	[SyncVar]
	public float hunger = 100;

    Vector3 projectileAngle;
    public GameObject bullet;
    private bool canAttack = true;

	//[SyncVar]
	//public int food = 0;
	//[SyncVar]
	//public int wood = 0;

	// Use this for initialization
	void Start () {
		health = 100;	
		Inventory_Script.health = 100;
		hunger = 100;
		Inventory_Script.hunger = 100;
		Inventory_Script.numVine = 0;
		Inventory_Script.numFood = 1;
		Inventory_Script.numWood = 0;
		Inventory_Script.boat = false;
		Inventory_Script.hasAxe = false;
    //[SyncVar]
    //public int food = 0;
    //[SyncVar]
    //public int wood = 0;

    // Use this for initialization
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
            return;

        projectileAngle = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            //transform.Translate(Vector3.left * speed * Time.deltaTime);
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            //transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.down * speed * offSet * Time.deltaTime);

        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.up * speed * offSet * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            canAttack = false;
            CmdShoot();
            Invoke("EnableShoot", .5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
            speed = 20;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            speed = 10;

		if (Input.GetKeyDown (KeyCode.Space))
		{
			if (Inventory_Script.numFood != 0 && hunger < 100) {
				hunger += 3;
				Inventory_Script.hunger += 3;
				Inventory_Script.numFood--;
			}
		}

		hunger -= 0.8f * Time.deltaTime;

		if ((transform.position.y <= -1) || (health <= 0) || hunger <= 0)
        {
            //CmdEnd();
            NetworkLobbyManager.singleton.ServerChangeScene("LoseGame");
        }
    }

    //[Command]
    //public void CmdEnd()
    //{
    //    SceneManager.LoadScene("LoseGame");
    //}


    // http://answers.unity3d.com/questions/225788/fire-bullet-to-mouse-position-in-3d-space.html
    [Command]
    void CmdShoot()
    {

        // Instantiate(bullet, this.transform.position, Quaternion.LookRotation(Vector3.up, projectileAngle - transform.position));
        //Ray ray = GameObject.FindGameObjectWithTag
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log("Is clinet" + isClient);
            // cache oneSpawn object in spawnPt, if not cached yet
            GameObject projectile = Instantiate(bullet, this.transform.position, transform.rotation);
            // turn the projectile to hit.point
            projectile.GetComponent<Transform>().LookAt(transform);
            projectile.GetComponent<Transform>().transform.position = new Vector3(projectile.GetComponent<Transform>().transform.position.x, 
                                                                                  transform.position.y, 
                                                                                  projectile.GetComponent<Transform>().transform.position.z);
            // accelerate it
            //Debug.Log(projectile);
            projectile.GetComponent<Rigidbody>().velocity = projectile.GetComponent<Transform>().forward * 25;
            NetworkServer.Spawn(projectile);
        }
    }

    void EnableShoot()
    {
        canAttack = true;
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Tree2") {
			//wood++;
			//Debug.Log("wood tree");
			if (Inventory_Script.hasAxe == true) {
				Inventory_Script.numWood++;

	//			other.GetComponent<Inventory_Script> ().numWood +=2;
				Destroy (other.gameObject);
			}
		}
		if (other.gameObject.tag == "Tree1") {
			if (other.GetComponent<TreeScript> ().hasFood) {
				Inventory_Script.numVine += 2;
				//other.GetComponent<Inventory_Script> ().numVine +=2;
				other.GetComponent<TreeScript> ().hasFood = false;
			}
		}
	
		if (other.gameObject.tag == "AxeChest") {
			Inventory_Script.hasAxe = true;
			//Instantiate (OpenChest, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			other.GetComponent<AxeChestScript> ().hasAxe = false;
		}

		if (other.gameObject.tag == "Enemy") {
			health -= 10;
			Inventory_Script.health -= 10;
		}
		if (other.gameObject.tag == "Hut") {
			while (Inventory_Script.numFood < 4)
				Inventory_Script.numFood++;
		}
	}

        //	void OnCollisionEnter(Collision other)
        //	{
        //		if (other.gameObject.tag == "Tree1") {
        //			food = food + other.gameObject.GetComponent<TreeScript> ().food;
        //			other.gameObject.GetComponent<TreeScript> ().food = 0;
        //		}
        //	}

    }
