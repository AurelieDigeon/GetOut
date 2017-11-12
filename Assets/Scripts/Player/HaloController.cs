using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Ce script gère l'activation d'un halo de lumière sur les objets.
 */
public class HaloController {
	/**
	 * Instance de la lumière à affecter aux objets
	 */
	private GameObject halo;

	/**
	 * Composante de lumière concernée
	 */
	private Light light;

	/**
	 * Initialise le halo. Doit être appelé avant toute utilisation
	 */
	public void Init(GameObject halo) {
		this.halo = halo;
		light = halo.GetComponent<Light> ();
	}

	/**
	 * Assigne le halo à un nouvel objet en adaptant sa taille et sa luminosité
	 * @param source Objet concerné
	 */
	public void SwitchHalo(GameObject source) {
		RemoveHalo ();

		//Calcul de la longueur maximale du Collider sur l'une des dimensions
		Collider sourceCollider = source.GetComponent<Collider> ();
		Vector3 colliderSize = sourceCollider.bounds.size;
		float haloSize = Mathf.Max (new float[] { colliderSize.x, colliderSize.y, colliderSize.z });

		//On adapte le diamètre du halo ainsi que son intensité en fonction de cette longueur
		light.range = haloSize + 0.3f;
		light.intensity = 1 * haloSize;

		//La lumière devient enfant relatif de l'objet (centre du Collider)
		halo.gameObject.SetActive (true);
		halo.transform.SetParent (sourceCollider.transform, false);
	}

	/**
	 * Supprime le halo
	 */
	public void RemoveHalo() {
		halo.gameObject.SetActive (false);
	}
}
