using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerTest : MonoBehaviour {
	void Update() {
		if (Input.GetKey ("q")) {
			Debug.Log ("q pressed");
			//On indique qu'on a fini notre test
			EventManager.Done("Test");
		}
	}
}
