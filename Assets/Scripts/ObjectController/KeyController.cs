using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyController : InteractionBase {

	//TODO remplacer par le système d'inventaire
	public GameObject player;

	//TODO remplacer par le système d'inventaire
	private AudioSource putInBag;

	void Start () {
		putInBag = GetComponent<AudioSource> ();

		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObserveKey));
		availableInteractions.Add (InteractionType.Take, new UnityAction (TakeKey));
	}

	void ObserveKey() {
		defaultInteractions.Observe ("Cette clé pourrait bien me servir...");
	}

	void TakeKey() {
		defaultInteractions.Observe ("Vous avez ramassé la clé !");
		putInBag.Play ();
		gameObject.GetComponent<MeshRenderer> ().enabled = false;
		player.GetComponent<PlayerInteractions> ().HasKey = true;
	}
}
