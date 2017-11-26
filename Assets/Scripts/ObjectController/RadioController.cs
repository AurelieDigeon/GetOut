using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RadioController : InteractionBase {
	private AudioSource radioSound;

	void Start () {
		radioSound = GetComponent<AudioSource> ();

		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObserveRadio));
		availableInteractions.Add (InteractionType.Use, new UnityAction (UseRadio));
	}

	private void ObserveRadio() {
		defaultInteractions.Observe ("Cette radio à l'air assez veille. Est-ce qu'elle fonctionne encore ?");
	}

	private void UseRadio() {
		radioSound.Play ();
	}
}
