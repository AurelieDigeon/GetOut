using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PianoController : InteractionBase {

	void Start () {
		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObservePiano));
	}
	
	private void ObservePiano() {
		defaultInteractions.Observe ("Piano");
	}
}
