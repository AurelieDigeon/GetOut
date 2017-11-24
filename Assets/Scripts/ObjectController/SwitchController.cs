using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * Ce controlleur permet de gérer assez génériquement les switchs.
 * On considère qu'il est associé à trois choses : 
 * 		- un interrupteur avec des animations on/off déclenchées par un booléen "isOn"
 * 		- un ensemble d'objets contenant une composante Light
 * 		- un ensemble de Material avec une composante Emission à activer quand la lumière émet
 * 		- un son de clic
 * 
 * Il suffit d'affecter ce script à un objet quelconque, et l'interaction de type Use déclenchera
 * le toggle sur les émissions et sur la lumière.
 */
public class SwitchController : InteractionBase {
	/**
	 * Objets contenant la lumière dépendant de l'interrupteur
	 */
	public GameObject[] lamps;

	/**
	 * Materials de la lumière pour gérer l'émission
	 */
	public Material[] mats;

	/**
	 * Animateur de l'interrupteur
	 */
	private Animator animator;

	/**
	 * Lumière à activer ou désactiver
	 */
	private List<Light> lights;

	/**
	 * Son de l'interrupteur
	 */
	private AudioSource clickSound;

	void Start () {
		//Initialisation des composants
		animator = GetComponentInParent<Animator> ();
		lights = new List<Light> ();
		clickSound = GetComponent<AudioSource> ();
		foreach (var obj in lamps) {
			lights.Add (obj.GetComponent<Light> ());
		}

		//Gestion bizarre de Unity, on désactive de base à la main
		foreach (var mat in mats) {
			mat.DisableKeyword ("_EMISSION");
		}

		//Initialisation des interactions
		availableInteractions.Add (InteractionType.Use, new UnityAction (UseSwitch));
	}

	/**
	 * Méthode d'utilisation permettant d'activer et de désactiver l'interrupteur
	 */
	public void UseSwitch() {
		bool isOn = !animator.GetBool ("isOn");
		clickSound.Play ();

		//Animation du switch
		animator.SetBool ("isOn", isOn);

		//Mise à jour de l'état de toutes les lumières
		foreach (var light in lights) {
			light.enabled = isOn;
		}

		//Mise à jour de l'émission de tous les Material dépendant des lumières
		foreach(var mat in mats) {
			if (isOn)
				mat.EnableKeyword ("_EMISSION");
			else
				mat.DisableKeyword ("_EMISSION");
		}
	}
}
