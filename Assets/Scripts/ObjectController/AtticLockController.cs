using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AtticLockController : InteractionBase {

	public void Start () {
		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObserveLock));
		availableInteractions.Add (InteractionType.Use, new UnityAction (UseLock));
	}

	public void UseLock() {
		//On ne peut utiliser le verrou qu'une seule fois
		availableInteractions.Remove (InteractionType.Use);

		//On indique que le verrou a été utilisé
		EventManager.Done("UseAtticLock");
	}

	public void ObserveLock() {
		defaultInteractions.Observe ("Patience... Suivez le tutoriel ;)");
	}
}
