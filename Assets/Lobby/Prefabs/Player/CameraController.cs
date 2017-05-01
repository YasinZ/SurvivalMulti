using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private bool set = false;

	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update()
    {
        if (!set)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            foreach (GameObject player in players)
                if (player.GetComponent<moveController>().isLocalPlayer)
                {
                    gameObject.transform.parent = player.transform;
                    Vector3 pos = new Vector3(0, 12, -22);
                    gameObject.transform.localPosition = pos;
                }

        }
    }
}
