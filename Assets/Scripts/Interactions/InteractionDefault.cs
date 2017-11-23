using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Cette classe est un singleton qui implémente des interactions par défaut, par exemple
 * pour l'observation et la mise dans l'inventaire.
 * 
 * Les classes implémentant IInteractable sont invitées à les utiliser
 * dans les cas standards pour éviter la redondance.
 */
public class InteractionDefault : MonoBehaviour {
	/**
	 * Image de fond du texte d'informations
	 */
	private Image imageInfo;

	/**
	 * Texte d'information
	 */
	private Text textInfo;

	/**
	 * Récupération des éléments UI
	 */
	private void Awake() {
		GameObject observePanel = GameObject.Find("Canvas/InfoPanel");
		imageInfo = observePanel.GetComponent<Image> ();
		textInfo = observePanel.GetComponentInChildren<Text> ();

		//Pas affiché par défaut
		imageInfo.canvasRenderer.SetAlpha (0.0f);
		textInfo.canvasRenderer.SetAlpha (0.0f);
	}

	/**
	 * Cette méthode affiche un message de description d'un objet dans un panel dédié sur l'écran (overlay)
	 */
	public void Observe(string text) {
		textInfo.text = text;
		imageInfo.CrossFadeAlpha (1.0f, 0.5f, false);
		textInfo.CrossFadeAlpha (1.0f, 0.5f, false);
	}

	/**
	 * Cette méthode générique permet d'indiquer que l'interaction en cours est terminée.
	 */
	public void EndInteractions() {
		//Fade out de la fenêtre d'informations
		imageInfo.CrossFadeAlpha (0.0f, 0.5f, false);
		textInfo.CrossFadeAlpha (0.0f, 0.5f, false);
	}
}
