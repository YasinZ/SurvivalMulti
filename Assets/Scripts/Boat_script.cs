using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boat_script : MonoBehaviour {
	public GameObject popUp;

	// Use this for initialization
	void Start () {
		popUp.SetActive (false);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && Inventory_Script.boat)
			SceneManager.LoadSceneAsync (2);
		else if (other.gameObject.tag == "Player" && !Inventory_Script.boat) 
			popUp.SetActive (true);
	}
	void OnTriggerExit(Collider other)
	{
		popUp.SetActive (false);
	}
}

