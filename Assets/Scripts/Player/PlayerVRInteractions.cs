using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * Ce script gère les interactions du joueur principal, y compris le ray-casting.
 */
public class PlayerVRInteractions : MonoBehaviour {
	/**
	 * Source du raycast
	 */
	public GameObject RaycastSource;

	/**
	 * Prefab contenant le Halo
	 */
	public GameObject HaloPrefab;

	/**
	 * Rendu du RayCasting
	 */
	private LineRenderer m_Line;

	/**
	 * Controlleur du Halo
	 */
	private HaloController m_Halo;

	/**
	 * Sauvegarde de l'objet Interactable précédemment raycasté
	 */
	private InteractionBase oldObject = null;

	//TODO à remplacer par le système d'inventaire
	public bool HasKey = false;

	void Start() {
		m_Line = GetComponent<LineRenderer> ();
		m_Line.enabled = false;
		m_Halo = new HaloController ();
		m_Halo.Init (Instantiate(HaloPrefab));
	}

	void Update () {
		PerformRaycast ();
	}

	/**
	 * Gère le raycasting du joueur, et appelle les fonctions en charge des interactions et des éléments graphiques.
	 */
	private void PerformRaycast () {
		
		RaycastHit hit;
		//On touche quelque chose avec le Raycast
		if(Physics.Raycast (RaycastSource.transform.position, transform.up, out hit, Mathf.Infinity)) {
			//Affichage du rayon
			DrawRaycast (RaycastSource.transform.position, hit.point);
			GameObject obj = hit.collider.gameObject;
			InteractionBase objScript;
			//Si l'objet propose des interactions, on affiche un halo et on écoute les entrées
			if ((objScript = obj.GetComponent<InteractionBase> ()) != null) {
				oldObject = objScript;

				//Afficher le halo en fonction de la propriété dédiée
				if(objScript.ShowHalo)
					m_Halo.SwitchHalo (obj);

				//Gestion des entrées de l'utilisateur
				CheckInputs (objScript);
			}
			//Sinon, on s'assure que le halo n'est pas affiché
			else {
				m_Halo.RemoveHalo ();
				//On prévient l'objet que l'on ne tente plus d'interagir avec lui
				if (oldObject != null) {
					oldObject.EndObserve ();
					oldObject = null;
				}
			}
		}
	}

	/**
	 * Gère les interactions entre le joueur (via les input) et les objets interactifs (i.e. avec un composant implémentant IInteractable)
	 * @param objScript Objet implémentant IInteractable
	 */
	private void CheckInputs (InteractionBase objScript) {
		//On récupère les interactions possibles dans ce contexte
		var interactions = objScript.GetInteractions (gameObject);

		//Bouton gauche pressé, observation
		if (Input.GetButtonDown ("Fire1")) {
			UnityAction observe;
			if (interactions.TryGetValue (InteractionType.Observe, out observe))
				observe.Invoke ();
		}
	}

	/**
	 * Dessine un rayon entre le joueur et l'endroit où il regarde
	 * @param hitPoint Point touché
	 */
	private void DrawRaycast(Vector3 startPoint, Vector3 hitPoint) {
		m_Line.enabled = true;
		m_Line.SetPosition (0, startPoint);
		m_Line.SetPosition (1, hitPoint);
	}
}
