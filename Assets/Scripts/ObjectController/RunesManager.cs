using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Ce manager se charge de vérifier périodiquement si toutes les runes sont posées sur un socle. Si c'est le cas il lève un événement.
 */
public class RunesManager : MonoBehaviour {
	/**
	 * Runes à regarder
	 */
	public GameObject []Runes;

	/**
	 * Etat actuel du puzzle
	 */
	public bool IsCompleted = false;

	void Start () {
			
	}

	void FixedUpdate () {
		foreach (var rune in Runes) {
			if (!rune.GetComponent<PuzzlePieceController> ().HasSocle) {
				//Si le puzzle était terminé mais est cassé par la suite, on le signale
				if (IsCompleted) {
					EventManager.Done ("PuzzleBroken");
				}
				IsCompleted = false;
				return;
			}
		}
		//Si le puzzle était cassé avant mais terminé maintenant, on le signale
		if(!IsCompleted) 
			EventManager.Done ("PuzzleCompleted");
		IsCompleted = true;
	}
}
