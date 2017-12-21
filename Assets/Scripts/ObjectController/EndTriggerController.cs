using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EndTriggerController : MonoBehaviour {
	public TextMesh endText;
	private Stopwatch sw;

	public void Awake() {
		sw = new Stopwatch ();
		sw.Start ();
	}
	void OnTriggerEnter (Collider other)
	{
		sw.Stop ();
		endText.text = "Bravo !\nVous avez réussi\nà sortir\nen " + sw.Elapsed.Minutes + " minutes !";	
	}
}
