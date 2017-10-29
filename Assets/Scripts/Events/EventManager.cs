using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * Cette classe est un singleton qui gère le système de notifications d'événements.
 * Les différentes classes peuvent demander à être notifiée d'un événement par l'appel d'une méthode.
 * Quand l'événement se produit (peut être déclenché par une autre classe), les abonnés sont appelés via leur méthode.
 * Les classes peuvent demander à ne plus être notifiées à tout moment.
 * 
 * Cette classe gère aussi les causalités à réaliser après une action.
 */
public class EventManager {
	/**
	 * Dictionnaire chaîne - évenement permettant de lier le nom d'un événement à la fonction à exécuter
	 */
	private Dictionary<string, UnityEvent> events;

	/**
	 * Dictionnaire chaîne - liste de chaîne liant les causalités des événements : une action terminée peut en déclencher plusieurs autres
	 */
	private Dictionary<string, List<string>> causalities;

	private static EventManager instance = null;

	private EventManager() {
		events = new Dictionary<string, UnityEvent> ();
		causalities = new Dictionary<string, List<string>> ();
	}

	/**
	 * Instance du Singleton
	 */
	public static EventManager Instance {
		get {
			if (instance == null)
				instance = new EventManager ();
			return instance;
		}
	}

	/**
	 * Associe un callback à un événement
	 * @param name Nom de l'événement
	 * @param callback Fonction à appeler
	 */
	public static void StartListening(string name, UnityAction callback) {
		UnityEvent currentEvent = null;
		//L'évenement existe, on ajoute le callback
		if(Instance.events.TryGetValue(name, out currentEvent)) {
			currentEvent.AddListener(callback);
		}
		//Sinon, on le crée
		else {
			currentEvent = new UnityEvent ();
			currentEvent.AddListener (callback);
			Instance.events.Add (name, currentEvent);
		}
	}

	/**
	 * Enlève un callback d'un événement
	 * @param name Nom de l'événement
	 * @param callback Fonction à appeler
	 */
	public static void StopListening(string name, UnityAction callback) {
		UnityEvent currentEvent = null;
		//L'évenement existe, on enlève le callback
		if(Instance.events.TryGetValue(name, out currentEvent)) {
			currentEvent.RemoveListener(callback);
		}
	}

	/**
	 * Ajoute un lien de causalité avec un événement
	 * @param afterEvent Action déclencheuse
	 * @param invokeEvent Evénement à déclencher après l'exécution de afterEvent
	 */
	public static void AddCausality(string afterEvent, string invokeEvent) {
		List<string> events = null;
		if (Instance.causalities.TryGetValue (afterEvent, out events)) {
			events.Add (invokeEvent);
		}  
		else {
			events = new List<string> ();
			events.Add (invokeEvent);
			Instance.causalities.Add (afterEvent, events);
		}
	}

	/**
	 * Déclenche les liens de causalité après exécution d'une action
	 * @param eventDone Nom de l'action terminée
	 */
	public static void Done(string eventDone) {
		List<string> eventsToInvoke = null;
		//On déclenche tous les événements listés dans les causalités de l'action terminée
		if (Instance.causalities.TryGetValue(eventDone, out eventsToInvoke)) {
			foreach (string eventToInvoke in eventsToInvoke) {
				Trigger (eventToInvoke);
			}
		}	
	}

	/**
	 * Déclenche un évenement en appelant tous ses callbacks.
	 * @param name Nom de l'événement
	 */
	public static void Trigger(string name) {
		UnityEvent currentEvent = null;
		if(Instance.events.TryGetValue(name, out currentEvent)) {
			currentEvent.Invoke();
		}
	}
}
