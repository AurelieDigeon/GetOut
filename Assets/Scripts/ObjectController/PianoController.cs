using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * Cette classe gère le piano. Il sait interpréter des mélodies remontées par ses enfants (notes physiques).
 * Les mélodies ne gèrent pas la hauteur mais seulement les notes elles-mêmes (C4 = C5, par exemple).
 */
public class PianoController : InteractionBase {

	/**
	 * Mélodie reconnaissable par le piano
	 */
	public string melody;

	/**
	 * Position dans la mélodie
	 */
	private int melodyCounter = 0;

	void Start () {
		availableInteractions.Add (InteractionType.Observe, new UnityAction (ObservePiano));
	}
	
	private void ObservePiano() {
		defaultInteractions.Observe ("Piano");
	}

	/**
	 * Permet de signaler au piano qu'une de ses touches a été pressée
	 * @keyNote nom de la note (A - G)
	 */
	public void KeyPressed(char keyNote) {
		//Position correcte dans la mélodie
		if (melody [melodyCounter] == keyNote) {
			//Mélodie complétée : on le signale et on revient à 0
			if (melodyCounter == melody.Length - 1) {
				EventManager.Done ("MelodyPlayed");
				melodyCounter = 0;
			}
			//Sinon on avance dans la mélodie
			else
				melodyCounter++;
		} 
		//Si erreur, on revient au début
		else
			melodyCounter = 0;
	}
}
