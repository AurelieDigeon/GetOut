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
	 * @param target Objet interactible receveur
	 * @param type Type d'interaction
	 */
	public bool CanInteract(GameObject source, InteractionBase target, InteractionType type) {
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
	private bool CanObserve(GameObject source, InteractionBase target) {
		//Le joueur peut observer tous les objets qui proposent d'être observés
		return source.CompareTag("Player");
	}

	/**
	 * Indique si un objet peut prendre un autre objet
	 */
	private bool CanTake(GameObject source, InteractionBase target) {
		return source.CompareTag("Player");
	}

	/**
	 * Indique si un objet peut utiliser un autre objet
	 */
	private bool CanUse(GameObject source, InteractionBase target) {
		if (source.CompareTag ("Player")) {
			FixedJoint fx;
			//Si le joueur veut utiliser le verrou, il faut qu'il ait ramassé la clé avant !
			if (target.GetType () == typeof(AtticLockController)) {
				//On regarde si le joueur tient quelque la clé
				if (fx = source.GetComponent<FixedJoint> ())
					return fx.connectedBody.gameObject.GetComponent<AtticKeyController> () != null;
				return false;
			}

				//Si le joueur veut utiliser la porte principale, il faut qu'il ait ramassé la clé du placard avant !
			if (target.GetType () == typeof(MainDoorController)) {
				//On regarde si le joueur tient quelque la clé du placard
				if (fx = source.GetComponent<FixedJoint> ())
					return fx.connectedBody.gameObject.GetComponent<KeyController> () != null;
				return false;
			}
			return true;
		}
		return false;
	}
}