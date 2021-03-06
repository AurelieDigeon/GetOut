using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * Script du pinceau pour l'ouverture du tableau
 */
public class BrushController : InteractionBase {
	void Start () {
		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObserveBrush));	
		availableInteractions.Add (InteractionType.Take, new UnityAction (TakeBrush));
	}

	public void ObserveBrush() {
		defaultInteractions.Observe ("Quel drôle d'endroit pour un pinceau...");
	}

	public void TakeBrush() {
		//Libération des contraintes
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		defaultInteractions.Take (source, gameObject);
	}
}
