using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TVController : InteractionBase {

	void Start () {
		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObserveTV));
	}

	void ObserveTV() {
		defaultInteractions.Observe ("Quelle vieille télévision ! Je me demande si elle capte des chaines.");
	}
}
