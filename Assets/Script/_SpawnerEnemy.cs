using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SpawnerEnemy : MonoBehaviour {

	[SerializeField]
	public GameObject _ahihi;

	// Use this for initialization
	void Start () {
		StartCoroutine (ahihi());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator ahihi(){
		//yield return new WaitForSeconds (Random.Range (3f, 6f));

		yield return new WaitForSeconds (1f);

		Vector3 tempPos = transform.localPosition;

		Instantiate (_ahihi, tempPos, Quaternion.identity);

		StartCoroutine (ahihi());
	}
}
