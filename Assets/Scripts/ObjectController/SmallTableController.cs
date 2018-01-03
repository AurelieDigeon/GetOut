using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SmallTableController : MonoBehaviour {
	private Animator animator;
	private AudioSource sound;

	void Start () {
		animator = GetComponentInChildren<Animator>();
		sound = GetComponent<AudioSource> ();
		EventManager.StartListening("TriggerSmallDoor", new UnityAction(TriggerSmallTable));
	}

	void TriggerSmallTable() {
		animator.SetBool("isOpen", !animator.GetBool("isOpen"));
		sound.PlayDelayed (0.5f);
	}
}
