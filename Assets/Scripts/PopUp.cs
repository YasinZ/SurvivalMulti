using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour {

	void Start () {
		this.gameObject.SetActive (false);
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player") 
			this.gameObject.SetActive (true);
	}
	void OnTriggerExit(Collider other)
	{
		this.gameObject.SetActive (false);
	}

}
