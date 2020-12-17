using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	public Text _endScoreText;

	//Sound
	[SerializeField]
	private AudioSource _audioSource;

	[SerializeField]
	private AudioClip _diedPing;

	public adding _point;
	// Use this for initialization
	void Start () {
		
		_point = GameObject.Find ("PointManager").GetComponent<adding> ();
		_endScoreText = GameObject.Find ("EndScoreText").GetComponent<Text> ();
		_audioSource = GetComponent<AudioSource> ();
		_setEndScoreText ();
		//_died ();
	}


	// Update is called once per frame
	void Update () {
		_setEndScoreText ();
		_died ();
	}

	void _setEndScoreText(){
		int temp = _point.score;
		_endScoreText.text = "End Score: " + temp;
	}

	void _died(){
		if(gameObject.activeSelf){
			_audioSource.PlayOneShot (_diedPing);

		}
		Destroy (gameObject.GetComponent<GameOver> ()); //Destroy Script after play one shot sound
	}

}
