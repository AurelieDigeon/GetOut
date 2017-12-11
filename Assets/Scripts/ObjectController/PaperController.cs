using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PaperController : MonoBehaviour {

	void Start () {
		EventManager.StartListening("PaperFall", new UnityAction(Fall));
	}

	void Fall() {
		this.GetComponent<Animation>().Play();
	}
}
