using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kill_Player : MonoBehaviour {
	public GameObject GameOver;
	// Use this for initialization
	void Start () {
		GameOver = GameObject.Find ("GameOver");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "mid")
		{
			//GameOver.SetActive (true);
			//Time.timeScale = 0;
			Destroy(GameObject.Find("Player"));

		}
		
		if (col.gameObject.tag == "top")
		{
			Destroy(GameObject.Find("ninjagirl"));
		}
	}
}
