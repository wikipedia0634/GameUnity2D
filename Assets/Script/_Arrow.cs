using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Arrow : MonoBehaviour {

	public static _Arrow instance;

	public Vector2 velocity;
	public int check; // 1 == left and  2 == right

	[SerializeField]
	public AudioSource _audioSource;

	[SerializeField]
	public AudioClip _arrowPing;

	// Use this for initialization
	void Start () {
		_makeInstance ();
		_audioSource = GetComponent<AudioSource> ();
		_audioSource.PlayOneShot (_arrowPing);
	}

	// Update is called once per frame
	void FixedUpdate () {
		_arrowAttackLeft ();
	}

	//Make Instance
	public void _makeInstance(){
		if (instance == null) {
			instance = this;
		}
	}

	public void _arrowAttackLeft(){
		Vector3 tempPos = transform.localPosition;
		Vector3 tempScale = transform.localScale;

		//Vector3 tempScalePlayer = GameObject.FindWithTag ("Player").transform.localScale;

		//		if (tempScalePlayer.x < 0) {
		//			tempScale.x = 0.3f;
		//			tempPos.x -= velocity.x * Time.deltaTime;
		//		} else {
		//			tempScale.x = -0.3f;
		//			tempPos.x += velocity.x * Time.deltaTime;
		//		}

		tempScale.x = 0.5f;
		tempPos.x -= velocity.x * Time.deltaTime;


		transform.localScale = tempScale;
		transform.localPosition = tempPos;

	}

	public void _arrowAttackRight(){
		Vector3 tempPos = transform.localPosition;
		Vector3 tempScale = transform.localScale;

		Vector3 tempScalePlayer = GameObject.FindWithTag ("Player").transform.localScale;

		//		if (tempScalePlayer.x < 0) {
		//			tempScale.x = 0.3f;
		//			tempPos.x -= velocity.x * Time.deltaTime;
		//		} else {
		//			tempScale.x = -0.3f;
		//			tempPos.x += velocity.x * Time.deltaTime;
		//		}

		tempScale.x = -0.3f;
		tempPos.x += velocity.x * Time.deltaTime;


		transform.localScale = tempScale;
		transform.localPosition = tempPos;

	}
}
