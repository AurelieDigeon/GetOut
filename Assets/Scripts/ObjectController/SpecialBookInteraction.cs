using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpecialBookInteraction : InteractionBase {
	void Start () {
		availableInteractions.Add(InteractionType.Observe, new UnityAction (ObserveSpecialBook));
		availableInteractions.Add(InteractionType.Use, new UnityAction (UseSpecialBook));
	}

	public void ObserveSpecialBook() {
		defaultInteractions.Observe ("Ce livre a l'air d'avoir quelque chose de spécial...");
	}

	public void UseSpecialBook() {
		EventManager.Done("SpecialBookUsed");
		availableInteractions.Remove(InteractionType.Use);
	}
}
