using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BookInteraction : InteractionBase {

	/**
	 * Message à afficher lors de la consultation du livre
	 */
	public string message;

	void Start () {
		availableInteractions.Add(InteractionType.Observe, new UnityAction (ObserveBook));
	}

	public void ObserveBook() {
		defaultInteractions.Observe (message);	
	}
}
