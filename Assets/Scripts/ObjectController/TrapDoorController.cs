using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrapDoorController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		EventManager.StartListening ("OpenTrapdoor", new UnityAction (open));
	}

	public void open() {
		this.GetComponent<Animation>().Play("TrapAnimation");
		this.GetComponent<AudioSource>().Play();
	}
}
