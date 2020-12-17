using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField]
    private GameObject planedich;
    private BoxCollider2D box;
     void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }
    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnerPlandich());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator SpawnerPlandich()
    {
        yield return new WaitForSeconds(Random.Range(1f, 8f));
        float minX = -box.bounds.size.x / 3f;
        float maxX = box.bounds.size.x / 3f;
        Vector3 temp = transform.localPosition;
        temp.x = Random.Range(minX, maxX);
        Instantiate(planedich, temp, Quaternion.identity);
        StartCoroutine(SpawnerPlandich());
    }
}
