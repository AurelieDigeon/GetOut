using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Classe de test d'interactions associée à un objet proposant d'être observé et utilisé
public class InteractionTest : InteractionBase {
	void Start () {
		// Add available interactions
		availableInteractions.Add(InteractionType.Observe, new UnityAction (Observe));
		availableInteractions.Add(InteractionType.Use, new UnityAction (Use));
	}

	public void Observe() {
		Debug.Log ("observe");
	}

	public void Use() {
		Debug.Log ("use");
		EventManager.Done("UseBall");
	}
}
