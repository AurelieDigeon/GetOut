using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TVCaseController : InteractionBase {
	private Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();

		availableInteractions.Add (InteractionType.Use, new UnityAction (ToggleCase));
	}
	
	private void ToggleCase() {
		animator.SetBool ("isOpen", !animator.GetBool ("isOpen"));
	}
}
