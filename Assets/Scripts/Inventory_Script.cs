using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;

public class Inventory_Script : NetworkBehaviour {
	public Text foodCount;
	public Text woodCount;
	public Text vineCount;
//	public Text boatCount;
	public Image boatImage;
	public Image axeImage;
	public Image healthbar;
	public Image hungerbar;

	//public GameObject[] foodTrees;
	//public GameObject[] woodTrees;
	//[SyncVar]
	public static int numFood = 0;
	//[SyncVar]
	public static int numWood = 0;
	//[SyncVar]
	public static int numVine = 0;
	//[SyncVar]
	public static bool boat = false;
	public static bool hasAxe = false;
	public static int health = 100;
	public static float hunger = 100;

	// Use this for initialization
	void Start () {

		//axeImage = GameObject.FindGameObjectWithTag ("AxeImage").GetComponent<Image> ();
		axeImage.enabled = false;
		//foodCount = GameObject.FindGameObjectWithTag ("FoodCount").GetComponent<Text>();
		foodCount.text = "0";
		//woodCount = GameObject.FindGameObjectWithTag ("WoodCount").GetComponent<Text>();
		woodCount.text = "0";
		//vineCount = GameObject.FindGameObjectWithTag ("VineCount").GetComponent<Text>();
		vineCount.text = "0";
//		boatCount = GameObject.FindGameObjectWithTag ("BoatCount").GetComponent<Text>();
//		boatCount.text = "0";
		//foodTrees = GameObject.FindGameObjectsWithTag ("Tree1");
		//woodTrees = GameObject.FindGameObjectsWithTag ("Tree2");
		boatImage.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		foodCount.text = numFood.ToString ();
		woodCount.text = numWood.ToString ();
		vineCount.text = numVine.ToString ();
		if (numWood >= 10 && numVine >= 10) {
	//		boatCount.text = "1";
			boatImage.enabled = true;

			boat = true;
		}

		hunger -= 0.8f * Time.deltaTime;

		if (hasAxe) {
			axeImage.enabled = true;
		}

		healthbar.fillAmount = health / 100f;
		hungerbar.fillAmount = hunger / 100f;
	}
}
