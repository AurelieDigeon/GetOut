using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyController : InteractionBase {
	public void Start () {
		//La clé est cachée jusqu'à déclenchement de l'événement
		ShowHalo = false;

		EventManager.StartListening ("ShowMainKey", new UnityAction (ShowKey));
		EventManager.StartListening ("HideMainKey", new UnityAction (ShowKey));
	}

	public void ObserveKey() {
		defaultInteractions.Observe ("Quel drôle d'endroit pour ranger une clé...");
	}

	public void TakeKey() {
		defaultInteractions.Take (source, gameObject);
	}

	/**
	 * Méthode d'activation de la clé et d'autorisation des interactions / affichage du halo
	 */
	public void ShowKey() {
		ShowHalo = true;

		if(!availableInteractions.ContainsKey(InteractionType.Observe))
			availableInteractions.Add (InteractionType.Observe, new UnityAction (ObserveKey));
		if(!availableInteractions.ContainsKey(InteractionType.Take))
			availableInteractions.Add (InteractionType.Take, new UnityAction (TakeKey));
	}

	//Cache la clé, le halo et empêche les interactions
	public void HideKey() {
		ShowHalo = false;

		if(availableInteractions.ContainsKey(InteractionType.Observe))
			availableInteractions.Remove (InteractionType.Observe);
		if(availableInteractions.ContainsKey(InteractionType.Take))
			availableInteractions.Remove (InteractionType.Take);
	}
}
