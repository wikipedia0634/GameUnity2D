using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nhacnen : MonoBehaviour {
	//Sound
	[SerializeField]
	private AudioSource _audioSource;

	[SerializeField]
	private AudioClip _nhacnen;
	// Use this for initialization
	void Start () {
		_audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
