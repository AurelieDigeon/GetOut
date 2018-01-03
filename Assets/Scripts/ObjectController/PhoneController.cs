using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhoneController : InteractionBase {
	private AudioSource ringtone;

	void Start () {
		ringtone = GetComponent<AudioSource> ();
		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObservePhone));
		availableInteractions.Add (InteractionType.Use, new UnityAction (RingPhone));
	}

	public void ObservePhone() {
		defaultInteractions.Observe ("Ce vieux téléphone n'a pas l'air de fonctionner...");
	}

	public void RingPhone() {
		ringtone.Play ();
	}
}
