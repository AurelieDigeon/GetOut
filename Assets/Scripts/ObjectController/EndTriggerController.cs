using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTriggerController : MonoBehaviour {
	public TextMesh endText;

	public void Awake() {
		
	}
	void OnTriggerEnter (Collider other)
	{
		endText.text = "Bravo !\nVous avez réussi\nà sortir\nen " + (int)(Time.fixedTime/60) + " minutes !";	
	}
}
