using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BookInteraction : InteractionBase {

	// Use this for initialization
	void Start () {
		// Add available interactions
		availableInteractions.Add(InteractionType.Observe, new UnityAction (Observe));
		availableInteractions.Add(InteractionType.Use, new UnityAction (Use));
	}

	public void Observe() {
		Debug.Log ("observe book");
	}

	public void Use() {
		Debug.Log ("use book");
		EventManager.Done("UseBook");
	}
}
