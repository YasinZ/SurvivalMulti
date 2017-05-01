using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
	public Text timeText;
	private float start;
	public static string minutes;
	public static string hours;

	// Use this for initialization
	void Start () {
		start = Time.time;
		timeText = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		float timer = Time.time - start;
		minutes = ((int)timer % 60).ToString ();
		hours = (((int)timer / 60) % 12).ToString ();
		timeText.text = hours + ":" + minutes;
	}
}
