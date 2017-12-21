using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FrameController : InteractionBase {
	private bool isOpen = false;

	void Start () {
		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObserveFrame));
		availableInteractions.Add (InteractionType.Use, new UnityAction (UseFrame));
	}
	
	void ObserveFrame() {
		defaultInteractions.Observe ("Dans quel pays peut-on bien trouver ce genre de paysages ?");
	}

	/**
	 * Si l'utilisateur peut "utiliser" le tableau, il l'ouvre
	 */
	void UseFrame() {
		if (!isOpen) {
			GetComponent<Animation> ().Play ("FrameOpen");
			isOpen = true;
		}
	}
}
