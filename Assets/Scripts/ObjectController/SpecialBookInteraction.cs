using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpecialBookInteraction : InteractionBase {

	// Use this for initialization
	void Start () {
		// Add available interactions
		availableInteractions.Add(InteractionType.Observe, new UnityAction (Observe));
	}

	public void Observe() {
		Debug.Log ("observe special book");
		EventManager.Done("SpecialBookObserved");
		availableInteractions.Remove(InteractionType.Observe);
	}
}
