using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JarController : InteractionBase {
	void Start () {
		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObserveJar));
		availableInteractions.Add (InteractionType.Use, new UnityAction (UseJar));
	}
	
	void ObserveJar() {
		defaultInteractions.Observe ("Ce cerveau semble être là depuis plusieurs années...");
	}

	void UseJar() {
		GetComponentInChildren<Animation> ().Play ("BrainAnimation");
	}
}
