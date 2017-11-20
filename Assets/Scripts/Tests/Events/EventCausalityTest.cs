using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCausalityTest : MonoBehaviour {
	void Awake () {
		//La fin de l'évenement Test provoque le déclenchement de l'événement OpenDoor
		EventManager.AddCausality ("Test", "OpenDoor");
		EventManager.AddCausality("UseBall", "TriggerSmallDoor");
		Debug.Log ("Added Test -> OpenDoor causality");
	}
}
