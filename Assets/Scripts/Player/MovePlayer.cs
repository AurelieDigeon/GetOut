using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {


	public float speed;
	private GameObject cam;
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		cam = Camera.main.gameObject;

	}

	void Update()
	{

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Vector3 tempDir = cam.transform.forward;
		tempDir.y = 0;

		Vector3 htempDir = cam.transform.right;
		htempDir.y = 0;

		if (v < 0)
		{
			rb.MovePosition (transform.position - tempDir*speed + new Vector3(0,0,v)*Time.deltaTime*speed); 
		}
		else if (v > 0)
		{
			rb.MovePosition (transform.position + tempDir*speed + new Vector3(0,0,v)*Time.deltaTime*speed); 
		}

		if (h < 0)
		{
			rb.MovePosition (transform.position - htempDir*speed + new Vector3(h,0,0)*Time.deltaTime*speed); 
		}
		else if (h> 0)
		{
			rb.MovePosition (transform.position + htempDir*speed + new Vector3(h,0,0)*Time.deltaTime*speed); 
		}
	}
}