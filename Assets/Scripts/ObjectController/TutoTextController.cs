using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutoTextController : InteractionBase {

	private TextMesh textMesh;

	// Use this for initialization
	void Start () {
		textMesh = this.GetComponent<TextMesh>();
		EventManager.StartListening ("ShowTutoUse", new UnityAction (ShowTutoUse));

		ShowTutoObserve();
	}

	public void ShowTutoObserve() {
		textMesh.text = "Tu devrais aller regarder le livre \n sur la table derrière toi... \n Appuie sur le bouton \n au milieu de ta mannette";
	}

	public void ShowTutoUse () {
		textMesh.text = "Il est temps de commencer... \n Appuie sur le bouton, par terre à droite. \n Touche le avec ta baguette.";
	}
}
