using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzlePieceController : InteractionBase {

	/**
	 * Nom de la rune
	 */
	public string PieceName;

	/**
	 * Propriété indiquant si la rune est posée sur le socle
	 */
	public bool HasSocle { get; private set; }

	void Start () {
		HasSocle = false;
		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObservePiece));
		availableInteractions.Add (InteractionType.Take, new UnityAction (TakePiece));
	}

	public void ObservePiece() {
		defaultInteractions.Observe ("C'est une rune ancienne... " + PieceName [0] + ", pour " + PieceName + ".");
	}

	public void TakePiece() {
		defaultInteractions.Take (source, gameObject);
	}
		
	//Pièce posée sur un socle
	public void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag ("Socle"))
			HasSocle = true;
	}


	//Pièce enlevée d'un socle
	public void OnTriggerExit(Collider col) {
		if (col.gameObject.CompareTag ("Socle"))
			HasSocle = false;
	}
}
