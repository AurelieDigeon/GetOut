using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Ce singleton est un helper contenant la logique permettant de savoir si une interaction
 * est possible dans un certain contexte. Elle est fortement couplée au jeu.
 * 
 * Il gère les interactions de l'énumération InteractionType
 */
public class InteractionManager  {
	private static InteractionManager instance = null;

	private InteractionManager() { }

	public static InteractionManager Instance {
		get {
			if (instance == null)
				instance = new InteractionManager ();
			return instance;
		}
	}
	/**
	 * Unique méthode publique permettant de vérifier si un objet peut effectuer un type d'interaction sur un autre objet
	 * @param source Objet demandeur
	 * @param target Objet receveur
	 * @param type Type d'interaction
	 */
	public bool CanInteract(GameObject source, GameObject target, InteractionType type) {
		if (type == InteractionType.Observe)
			return CanObserve (source, target);
		else if (type == InteractionType.Take)
			return CanTake (source, target);
		else if (type == InteractionType.Use)
			return CanUse (source, target);
		return false;
	}

	/**
	 * Indique si un objet peut observer un autre objet
	 */
	private bool CanObserve(GameObject source, GameObject target) {
		//Le joueur peut observer tous les objets qui proposent d'être observés
		return source.CompareTag("Player");
	}

	/**
	 * Indique si un objet peut prendre un autre objet
	 */
	private bool CanTake(GameObject source, GameObject target) {
		return source.CompareTag("Player");
	}

	/**
	 * Indique si un objet peut utiliser un autre objet
	 */
	private bool CanUse(GameObject source, GameObject target) {
		return source.CompareTag("Player");
	}
}