using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * Cette classe est un modèle pour les objets interactibles, implémentant 
 * certaines méthodes redondantes autrement, comme la construction des interactions
 * disponibles dans un certain contexte.
 * 
 * Les classes enfants devraient simplement implémenter les méthodes d'interactions
 * et les enregistrer dans le dictionnaire. Voir InteractionTest pour un exemple.
 */
public abstract class InteractionBase : MonoBehaviour {
	protected InteractionManager im = InteractionManager.Instance;
	protected Dictionary<InteractionType, UnityAction> availableInteractions = new Dictionary<InteractionType, UnityAction>();
	
	public Dictionary<InteractionType, UnityAction> GetInteractions (GameObject source) {
		var interactions = new Dictionary<InteractionType, UnityAction> ();

		//Pour chaque interaction proposée par l'objet, si elle est réalisable dans le contexte actuel, on l'ajoute
		foreach (var pair in availableInteractions) {
			if (im.CanInteract(source, gameObject, pair.Key))
				interactions.Add (pair.Key, new UnityAction (pair.Value));
		}
		return interactions;
	}
}
