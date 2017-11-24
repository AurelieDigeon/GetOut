using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RadioController : InteractionBase {

	void Start () {
		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObserveRadio));
	}
	
	private void ObserveRadio() {
		defaultInteractions.Observe ("Radio");
	}
}
