using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FrameController : InteractionBase {

	void Start () {
		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObserveFrame));	
	}
	
	void ObserveFrame() {
		defaultInteractions.Observe ("Dans quel pays peut-on bien trouver ce genre de paysages ?");
	}
}
