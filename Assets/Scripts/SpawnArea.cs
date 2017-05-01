using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnArea : NetworkBehaviour {

    public GameObject area;

	// Use this for initialization
	void Start () {
        Instantiate(area, this.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
