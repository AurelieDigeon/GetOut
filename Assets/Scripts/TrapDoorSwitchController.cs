using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrapDoorSwitchController : InteractionBase {
	/**
	 * Animateur de l'interrupteur
	 */
	private Animator animator;

	// Use this for initialization
	void Start () {
		//Initialisation des composants
		animator = GetComponentInParent<Animator> ();

		//Initialisation des interactions
		availableInteractions.Add (InteractionType.Use, new UnityAction (UseTrapdoorSwitch));
	}

	public void UseTrapdoorSwitch() {
		Debug.Log ("UseTrapdoorSwitch !");
		bool isOn = !animator.GetBool ("isOn");
		//Animation du switch
		animator.SetBool ("isOn", isOn);

		EventManager.Done("UseTrapdoorSwitch");
	}
}
