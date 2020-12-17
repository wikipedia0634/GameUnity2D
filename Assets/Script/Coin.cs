using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	public Animator animator;
	public adding add;



	// Use this for initialization
	void Start () {

		add = GameObject.FindWithTag ("point").GetComponent<adding> ();

		animator = GetComponent<Animator> ();

		//_audioSource = GameObject.Find ("Player").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.tag == "Player"){
			add.UpdateScore ();

			Destroy (gameObject);
		}
			
	}


}
