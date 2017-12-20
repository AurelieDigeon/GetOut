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

	/**
	 * Dictionnaire des interactions possibles selon l'état => interne <= de l'objet uniquement
	 */
	protected Dictionary<InteractionType, UnityAction> availableInteractions = new Dictionary<InteractionType, UnityAction>();

	/**
	 * Référence vers le composant contenant les interactions par défaut
	 */
	protected InteractionDefault defaultInteractions;

	/**
	 * Référence vers le dernier objet ayant tenté d'interagir avec l'objet courant
	 */
	protected GameObject source;

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

		//Sauvegarde
		this.source = source;

		//Pour chaque interaction proposée par l'objet, si elle est réalisable dans le contexte actuel, on l'ajoute
		foreach (var pair in availableInteractions) {
			if (im.CanInteract(source, this, pair.Key))
				interactions.Add (pair.Key, pair.Value);
		}
		return interactions;
	}

	/**
	 * Façade générique pour la méthode d'arrêt des interactions par défaut
	 * @param source Source de l'interaction
	 */
	public void EndInteractions(GameObject source) {
		defaultInteractions.EndInteractions (source);
	}

	/**
	 * Façade générique pour la méthode d'arrêt de l'observation par défaut
	 */
	public void EndObserve() {
		defaultInteractions.EndObserve ();
	}

	/**
	 * Façade générique pour la méthode d'arrêt du ramassage par défaut
	 * @param source Source de l'interaction
	 */
	public void EndTake(GameObject source) {
		defaultInteractions.EndTake (source);
	}
}
