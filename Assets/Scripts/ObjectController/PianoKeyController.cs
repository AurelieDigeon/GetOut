using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * Cette classe gère une touche du piano. Elle propose des interactions de type
 * Observe (identifiant de la touche) et Use (appui sur la touche).
 * 
 * Elle gère également la lecture d'un son lorsque la touche est appuyée.
 */
public class PianoKeyController : InteractionBase {
	/**
	 * Animation de la touche
	 */
	private Animation animation;

	/**
	 * Son de la touche
	 */
	private AudioSource sound;

	/**
	 * Référence au piano lui-même
	 */
	private PianoController piano;

	/**
	 * Nom de la note correspondante
	 */
	private char keyNote;

	void Start () {
		animation = GetComponent<Animation> ();
		sound = GetComponent<AudioSource> ();
		piano = GetComponentInParent<PianoController> ();
		keyNote = gameObject.tag [0];

		//Ajout des interactions
		availableInteractions.Add (InteractionType.Observe, new UnityAction (ReadKey));
		availableInteractions.Add (InteractionType.Use, new UnityAction (PressKey));
	}
	
	private void ReadKey() {
		
	}

	/**
	 * Appui sur la touche, on joue l'animation
	 */
	private void PressKey() {
		animation.Play ();
		sound.Play ();
		//On signale au piano la note jouée
		piano.KeyPressed (keyNote);
	}
}
