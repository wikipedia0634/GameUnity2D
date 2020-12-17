using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[SerializeField]
	private GameObject enemy;
	private BoxCollider2D box;

	void Awake()
	{
		box = GetComponent<BoxCollider2D>();
	}
	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnerEnemy());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnerEnemy()
	{
		yield return new WaitForSeconds(Random.Range(1f, 8f));
		float minX = -box.bounds.size.x / 3f;
		float maxX = box.bounds.size.x / 3f;
		Vector3 temp = transform.localPosition;
		temp.x = Random.Range(minX, maxX);
		Instantiate(enemy, temp, Quaternion.identity);
		StartCoroutine(SpawnerEnemy());
	}
}
