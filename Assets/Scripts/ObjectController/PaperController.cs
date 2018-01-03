using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PaperController : InteractionBase {

	void Start () {
		EventManager.StartListening("PaperFall", new UnityAction(Fall));

		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObservePaper));
		availableInteractions.Add (InteractionType.Take, new UnityAction (TakePaper));
	}

	void Fall() {
		this.GetComponent<Animation>().Play();
	}

	public void ObservePaper() {
		defaultInteractions.Observe ("Ce sont vraiment les bases du solfège...");
	}

	public void TakePaper() {
		defaultInteractions.Take (source, gameObject);
	}
}
