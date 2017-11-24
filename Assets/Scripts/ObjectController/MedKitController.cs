using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MedKitController : InteractionBase {
	void Start () {
		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObserveMedKit));
	}
	
	private void ObserveMedKit() {
		defaultInteractions.Observe ("Medkit");
	}
}
