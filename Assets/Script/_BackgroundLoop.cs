using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BackgroundLoop : MonoBehaviour {

	public float speed = 0.5f;
	Vector2 _startPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_backgroundLoop ();
	}
	//BackGround Loop

	void _backgroundLoop(){
		Vector2 offset = new Vector2 (Time.time * speed, 0);

		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
}
