using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWall : MonoBehaviour {

    //các khối vật cản
    public GameObject wallBasic;
    //GameObject vừa tạo
    public GameObject obvitri;

	public GameObject Arrow;

    // Use this for initialization


    void Start()
    {
        //chạy Creat();
        StartCoroutine(Creat());
		StartCoroutine(CreateArrow());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Creat()
    {
        //đợi 3s

        yield return new WaitForSeconds(Random.Range(1f,2.5f));
        //lấy vị trí để sinh ra
        Vector3 temp = obvitri.transform.position;
        //randum chiều cao
        temp.y = Random.Range(-6f,-2f);
        //Instantiate sinh ra wallbasic, temp vector3 
        Instantiate(wallBasic, temp, Quaternion.identity);
        StartCoroutine(Creat());
    }

	IEnumerator CreateArrow()
	{
		//đợi 3s

		yield return new WaitForSeconds(Random.Range(6f, 8f));
		//lấy vị trí để sinh ra
		Vector3 temp = obvitri.transform.position;
		//randum chiều cao
		temp.y = Random.Range(4f, -3f);
		//Instantiate sinh ra wallbasic, temp vector3 
		Instantiate(Arrow, temp, Quaternion.identity);
		StartCoroutine(CreateArrow());
	}
}
