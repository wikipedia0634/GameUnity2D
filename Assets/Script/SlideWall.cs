using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideWall : MonoBehaviour {
    //tốc độ di chuyển của wall , ground
    public float speed = 30f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //cho di chuyển 
        transform.Translate(Vector3.left * speed * Time.deltaTime);


    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
