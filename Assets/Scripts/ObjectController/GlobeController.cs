using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobeController : InteractionBase {

	// Use this for initialization
	void Start () {
		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObserveGlobe));
	}

	private void ObserveGlobe() {
		defaultInteractions.Observe ("Globe");
	}
}
