using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapdoorTriggerController : MonoBehaviour {
	public GameObject trap;

	private TrapDoorController trapController;

	public void Start() {
		trapController = trap.GetComponent<TrapDoorController> ();
	}

	/**
	 * Passage du joueur dans la trappe, on la ferme
	 */
	public void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			trapController.CloseTrapdoor ();
		}
	}
}
