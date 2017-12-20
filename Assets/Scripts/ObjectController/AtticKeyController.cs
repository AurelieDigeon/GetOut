using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * Représente une clé pouvant être ramassée
 */
public class AtticKeyController : InteractionBase {
	void Start () {
		availableInteractions.Add (InteractionType.Take, new UnityAction (TakeKey));
	}

	void TakeKey() {
		//Ramassage de la clé par la source de l'interaction
		defaultInteractions.Take (source, gameObject);

		EventManager.Done ("TakeKey");
	}
}
