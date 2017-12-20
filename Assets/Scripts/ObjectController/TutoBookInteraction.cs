using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutoBookInteraction : InteractionBase {

	public string message;
	// Use this for initialization
	void Start () {
		availableInteractions.Add(InteractionType.Observe, new UnityAction (ObserveBook));
	}

	public void ObserveBook() {
		defaultInteractions.Observe (message);
		EventManager.Done("ObserveTutoBook");
	}
}
