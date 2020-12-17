using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class adding : MonoBehaviour {
	public static adding instance;
	public Text scoretext;
	public int score=0;

	// Use this for initialization
	void Start () {
		_MakeInstance ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateScore(){
		score++;

		scoretext.text = "Score : " + score;

	}

	void _MakeInstance(){
		if(instance == null){
			instance = this;
		}

	}
}
