using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	// change scene khi ma dat du diem
	public void _ChangeScene(string name){
		Application.LoadLevel (name);
	}
}
