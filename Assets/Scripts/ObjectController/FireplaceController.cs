using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireplaceController : MonoBehaviour {
	private ParticleSystem particules;
	private Light lightning;

	public void Start () {
		particules = GetComponentInChildren<ParticleSystem> ();

		//On attend l'événement pour éteindre la cheminée
		EventManager.StartListening ("TurnOffFireplace", new UnityAction (TurnOffFireplace));
		EventManager.StartListening ("TurnOnFireplace", new UnityAction (TurnOnFireplace));
	}

	public void TurnOffFireplace() {
		particules.Stop ();
		Wait ();
	}

	public void TurnOnFireplace() {
		particules.gameObject.SetActive (true);
		particules.Play ();
	}

	IEnumerator Wait() {
		yield return new WaitForSeconds (1);
		particules.gameObject.SetActive (false);
	}
}
