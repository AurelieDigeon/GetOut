using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AtticLampController : InteractionBase {
	private Light light;

	/**
	 * Material pour toggle l'émission
	 */
	public Material mat;

	void Start () {
		light = gameObject.GetComponentInChildren<Light> ();
		availableInteractions.Add (InteractionType.Observe, new UnityAction(YeahSorryButThisIsNotTheRightThingToDoJustUseTheLamp));	
		availableInteractions.Add (InteractionType.Use, new UnityAction(ToggleLight));		
	}
	
	void ToggleLight() {
		//Changement de l'état de la lumière et de l'émission du material
		light.enabled = !light.enabled;
		if (light.enabled) {
			mat.EnableKeyword ("_EMISSION");
			EventManager.Done ("AtticLampOn");
		} else {
			mat.DisableKeyword ("_EMISSION");
			EventManager.Done ("AtticLampOff");
		}
	}

	void YeahSorryButThisIsNotTheRightThingToDoJustUseTheLamp() {
		//Si vous lisez ce code, mes respects éternels
		defaultInteractions.Observe("Bravo ! Vous observez la lampe. Pour l'utiliser, touchez là avec votre baguette.");
	}
}
