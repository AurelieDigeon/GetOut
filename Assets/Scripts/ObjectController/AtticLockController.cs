using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AtticLockController : InteractionBase {

	void Start () {
		availableInteractions.Add (InteractionType.Use, new UnityAction (UseLock));
	}

	void UseLock() {
		Debug.Log ("UseLock");
		//On ne peut utiliser le verrou qu'une seule fois
		availableInteractions.Remove (InteractionType.Use);

		//On indique que le verrou a été utilisé
		EventManager.Done("UseAtticLock");
	}
}
