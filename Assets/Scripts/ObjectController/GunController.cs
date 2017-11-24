using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class GunController : InteractionBase {

	void Start () {
		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObserveGun));	
	}

	void ObserveGun() {
		defaultInteractions.Observe ("Gun");
	}
}
