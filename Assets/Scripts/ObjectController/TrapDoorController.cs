using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrapDoorController : MonoBehaviour {
	private Animator anim;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
		//On écoute les triggers d'ouverture de porte
		EventManager.StartListening ("OpenTrapdoor", new UnityAction (OpenTrapdoor));
	}

	/**
	 * Ouverture de la trappe : animation et son
	 */
	public void OpenTrapdoor() {
		anim.SetBool ("isOpen", true);
		audio.Play();
	}

	public void CloseTrapdoor() {
		anim.SetBool ("isOpen", false);
		audio.Play();
	}
}
