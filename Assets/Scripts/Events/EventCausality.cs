using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Cette classe implémente les causalités entre évenements.
 */
public class EventCausality : MonoBehaviour {
	void Awake () {
		// Tutoriel
		// Quand on a observé le livre, on affiche le tuto pour utiliser
		EventManager.AddCausality ("ObserveTutoBook", "DoneObserving");

		//Quand on a utilisé la lampe, on afficher le tuto pour ramasser
		EventManager.AddCausality("AtticLampOn", "DoneUsing");

		//Quand on a ramassé la clé, on affiche le message de début de jeu
		EventManager.AddCausality("TakeKey", "DoneTaking");

		//Utilisation du Switch de la trappe
		EventManager.AddCausality ("UseAtticLock", "OpenTrapdoor");

		//Lecture du livre, le papier tomber
		EventManager.AddCausality ("SpecialBookUsed", "PaperFall");

		//Mélodie jouée : ouverture de la porte de placard
		EventManager.AddCausality("MelodyPlayed", "TriggerSmallDoor");

		//Puzzle complété : on éteint la cheminée et on active la clé
		EventManager.AddCausality ("PuzzleCompleted", "TurnOffFireplace");
		EventManager.AddCausality ("PuzzleCompleted", "ShowMainKey");

		//Puzzle cassé : on allume la cheminée et on désactive la clé
		EventManager.AddCausality ("PuzzleBroken", "TurnOnFireplace");
		EventManager.AddCausality ("PuzzleBroken", "HideMainKey");

		//Trappe fermée : on arrête la lumière clignotante
		EventManager.AddCausality("CloseTrapdoor", "StopFlickering");
	}
}
