using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainDoorController : InteractionBase {
	private Animator animator;

	void Start () {
		animator = GetComponentInChildren<Animator>();
		EventManager.StartListening("TriggerMainDoor", new UnityAction(TriggerMainDoor));

		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObserveDoor));
	}

	void TriggerMainDoor() {
		animator.SetBool("isOpen", !animator.GetBool("isOpen"));
	}

	private void ObserveDoor() {
		defaultInteractions.Observe ("Cette porte est fermée à double tour...");
	}
}
