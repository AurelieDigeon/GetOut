using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * Interface décrivant un objet proposant des interactions.
 * Tout objet implémentant cette interface doit implémenter une méthode renvoyant les interactions proposées
 */
public interface IInteractable {
	/**
	 * Renvoie les interactions possibles avec un objet.
	 * @param source GameObjet tentant d'interagir.
	 */
	Dictionary<InteractionType, UnityAction> GetInteractions (GameObject source);
}
