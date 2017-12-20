using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * Représente une clé pouvant être ramassée
 */
public class AtticKeyController : InteractionBase {
	public void Start () {
		availableInteractions.Add (InteractionType.Take, new UnityAction (TakeKey));
	}

	public void TakeKey() {
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		//Ramassage de la clé par la source de l'interaction
		defaultInteractions.Take (source, gameObject);

		EventManager.Done ("TakeKey");
	}

	public void ObserveKey() {
		defaultInteractions.Observe ("Mais qu'est-ce-que cette clé peut bien ouvrir ?");
	}
}
