using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTriggerController : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		Application.LoadLevel("End");
	}
}
