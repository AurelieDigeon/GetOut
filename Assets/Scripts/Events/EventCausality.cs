using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Cette classe implémente les causalités entre évenements.
 */
public class EventCausality : MonoBehaviour {
	void Awake () {
		//Utilisation du Switch de la trappe
		EventManager.AddCausality ("UseTrapdoorSwitch", "OpenTrapdoor");

		//Lecture du livre, le papier tomber
		EventManager.AddCausality ("SpecialBookUsed", "PaperFall");

		//Mélodie jouée : ouverture de la porte de placard
		EventManager.AddCausality("MelodyPlayed", "TriggerSmallDoor");
	}
}
