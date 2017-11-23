using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * Cette classe est un modèle pour les objets interactibles, implémentant 
 * certaines méthodes redondantes autrement, comme la construction des interactions
 * disponibles dans un certain contexte.
 * 
 * Cette classe compose également une classe d'interactions par défaut que ses enfants peuvent appeler.
 * 
 * Les classes enfants devraient simplement implémenter les méthodes d'interactions
 * et les enregistrer dans le dictionnaire. Voir InteractionTest pour un exemple.
 */
public abstract class InteractionBase : MonoBehaviour {
	protected InteractionManager im = InteractionManager.Instance;
	protected Dictionary<InteractionType, UnityAction> availableInteractions = new Dictionary<InteractionType, UnityAction>();
	protected InteractionDefault defaultInteractions;

	private void Awake() {
		//Récupération de l'instance des interactions par défaut
		GameObject defaultInterObj = GameObject.Find ("InteractionDefault");
		defaultInteractions = defaultInterObj.GetComponent<InteractionDefault> ();
	}

	/**
	 * Renvoie les interactions proposées par l'objet dans le contexte actuel
	 * @param source Origine de la demande d'interaction
	 */
	public Dictionary<InteractionType, UnityAction> GetInteractions (GameObject source) {
		var interactions = new Dictionary<InteractionType, UnityAction> ();

		//Pour chaque interaction proposée par l'objet, si elle est réalisable dans le contexte actuel, on l'ajoute
		foreach (var pair in availableInteractions) {
			if (im.CanInteract(source, gameObject, pair.Key))
				interactions.Add (pair.Key, pair.Value);
		}
		return interactions;
	}

	/**
	 * Façade générique pour la méthode d'arrêt des interactions par défaut
	 */
	public void EndInteractions() {
		defaultInteractions.EndInteractions ();
	}
}
