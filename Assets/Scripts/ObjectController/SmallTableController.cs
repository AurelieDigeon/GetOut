using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SmallTableController : MonoBehaviour {
	private Animator animator;

	void Start () {
		animator = GetComponentInChildren<Animator>();
		EventManager.StartListening("TriggerSmallDoor", new UnityAction(TriggerSmallTable));
	}

	void TriggerSmallTable() {
		animator.SetBool("isOpen", !animator.GetBool("isOpen"));
	}
}
