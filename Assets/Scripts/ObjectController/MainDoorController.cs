using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainDoorController : MonoBehaviour {
	private Animator animator;

	void Start () {
		animator = GetComponentInChildren<Animator>();
		EventManager.StartListening("TriggerMainDoor", new UnityAction(TriggerMainDoor));
	}

	void TriggerMainDoor() {
		Debug.Log("LOL");
		animator.SetBool("isOpen", !animator.GetBool("isOpen"));
	}
}
