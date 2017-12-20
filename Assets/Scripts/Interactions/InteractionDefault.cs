using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Cette classe est un singleton qui implémente des interactions par défaut, par exemple
 * pour l'observation et le ramassage.
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
	 * Panel UI ingame
	 */
	public GameObject ObservePanel;

	/**
	 * Récupération des éléments UI
	 */
	private void Awake() {
		imageInfo = ObservePanel.GetComponent<Image> ();
		textInfo = ObservePanel.GetComponentInChildren<Text> ();

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
	 * Cette méthode générique permet de ramasser un objet, c'est à dire de le fixer.
	 * @param source Source de l'interaction sur laquel fixer l'objet
	 * @param target Objet à ramasser : doit avoir un Rigidbody!!
	 */
	public void Take(GameObject source, GameObject target) {
		//Ajout de la liaison
		AddFixedJoint (source, target);
	}

	/**
	 * Cette méthode générique permet d'indiquer que l'interaction en cours est terminée.
	 * @param source Source de l'interaction
	 */
	public void EndInteractions(GameObject source) {
		EndObserve ();
		EndTake (source);
	}

	/**
	 * Cette méthode générique permet d'indiquer que l'observation est terminée.
	 */
	public void EndObserve() {
		//Fade out de la fenêtre d'informations
		imageInfo.CrossFadeAlpha (0.0f, 0.5f, false);
		textInfo.CrossFadeAlpha (0.0f, 0.5f, false);
	}

	/**
	 * Cette méthode générique permet d'indiquer que le ramassage est terminé.
	 * @param source Source de l'interaction
	 */
	public void EndTake(GameObject source) {
		//Si on avait ramassé un objet, on le libère
		RemoveFixedJoint(source);
	}

	private void AddFixedJoint(GameObject source, GameObject target) {
		//Création d'un liaison sur la source
		FixedJoint fx = source.AddComponent<FixedJoint> ();
		fx.breakForce = 2000000;
		fx.breakTorque = 2000000;

		//Liaison de la source et l'objet visé
		fx.connectedBody = target.GetComponent<Rigidbody>();
	}

	private void RemoveFixedJoint(GameObject source) {
		//Mesure de précaution, on itère sur tous les FixedJoint trouvés
		foreach (var fx in source.GetComponents<FixedJoint> ()) {
			fx.connectedBody = null;
			Destroy (fx);
		}
	}
}
