using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("destory", 1.5f);
	}

    void destory()
    {
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
    }
}
