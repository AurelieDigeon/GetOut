using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Classe de test d'interactions associée à un objet proposant d'être observé et utilisé
public class InteractionTest : MonoBehaviour, IInteractable {
	private InteractionManager im;

	// Use this for initialization
	void Start () {
		im = InteractionManager.Instance;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Dictionary<InteractionType, UnityAction> GetInteractions (GameObject source) {
		Dictionary<InteractionType, UnityAction> interactions = new Dictionary<InteractionType, UnityAction> ();
		if (im.CanInteract(source, gameObject, InteractionType.Observe))
			interactions.Add (InteractionType.Observe, new UnityAction (Observe));
		if (im.CanInteract (source, gameObject, InteractionType.Use))
			interactions.Add (InteractionType.Use, new UnityAction (Use));
		return interactions;
	}

	public void Observe() {
		Debug.Log ("observe");
	}

	public void Use() {
		Debug.Log ("use");
	}
}
