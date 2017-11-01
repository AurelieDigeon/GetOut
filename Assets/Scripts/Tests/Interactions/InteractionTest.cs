using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Classe de test d'interactions associée à un objet proposant d'être observé et utilisé
public class InteractionTest : MonoBehaviour, IInteractable {
	private InteractionManager im;
	private Dictionary<InteractionType, UnityAction> availableInteractions;

	// Use this for initialization
	void Start () {
		im = InteractionManager.Instance;	

		// Add available interactions
		availableInteractions.Add(InteractionType.Observe, new UnityAction (Observe));
		availableInteractions.Add(InteractionType.Use, new UnityAction (Use));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Dictionary<InteractionType, UnityAction> GetInteractions (GameObject source) {
		Dictionary<InteractionType, UnityAction> interactions = new Dictionary<InteractionType, UnityAction> ();

		foreach (KeyValuePair<InteractionType, UnityAction> pair in availableInteractions) {
			if (im.CanInteract(source, gameObject, pair.Key))
				interactions.Add (pair.Key, new UnityAction (pair.Value));
		}

		return interactions;
	}

	public void Observe() {
		Debug.Log ("observe");
	}

	public void Use() {
		Debug.Log ("use");
	}
}
