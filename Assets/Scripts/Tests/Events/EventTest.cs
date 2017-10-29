using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class EventTest : MonoBehaviour {
	void Start () {
		//L'évenement Test trigger Test et Test2.
		EventManager.StartListening ("OpenDoor", new UnityAction (UnlockDoor));
		EventManager.StartListening ("OpenDoor", new UnityAction (MoveDoor));
	}
	
	void UnlockDoor() {
		Debug.Log ("UnlockDoor triggered");	
	}

	void MoveDoor() {
		Debug.Log ("MoveDoor triggered");
	}
}
