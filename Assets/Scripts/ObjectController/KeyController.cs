using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyController : InteractionBase {
	void Start () {
		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObserveKey));
		availableInteractions.Add (InteractionType.Take, new UnityAction (TakeKey));
	}

	void ObserveKey() {
		defaultInteractions.Observe ("Cette clé pourrait bien me servir...");
	}

	void TakeKey() {
		//Libération des contraintes à la prise
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		defaultInteractions.Take (source, gameObject);
	}
}
