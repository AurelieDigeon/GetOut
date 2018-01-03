using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TVCaseController : InteractionBase {
	private Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();

		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObserveCase));
		availableInteractions.Add (InteractionType.Use, new UnityAction (ToggleCase));
	}

	public void ObserveCase() {
		defaultInteractions.Observe ("Qu'il a-t-il dans ce tiroir ?");
	}
	
	public void ToggleCase() {
		animator.SetBool ("isOpen", !animator.GetBool ("isOpen"));
	}
}
