using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * Ce script gère les interactions du joueur principal, y compris le ray-casting.
 */
public class PlayerInteractions : MonoBehaviour {
	/**
	 * Prefab contenant le Halo
	 */
	public GameObject HaloPrefab;

	/**
	 * Caméra depuis laquelle lancer le raycasting
	 */
	private Camera m_Camera;

	/**
	 * Rendu du RayCasting
	 */
	private LineRenderer m_Line;

	/**
	 * Controlleur du Halo
	 */
	private HaloController m_Halo;

	void Start() {
		m_Camera = Camera.main;
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
		//Là où regarde le joueur
		Ray ray = m_Camera.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		//On touche quelque chose avec le Raycast
		if(Physics.Raycast (ray, out hit, Mathf.Infinity)) {
			//Affichage du rayon
			DrawRaycast (hit.point);

			GameObject obj = hit.collider.gameObject;
			InteractionBase objScript;
			//Si l'objet propose des interactions, on affiche un halo et on écoute les entrées
			if ((objScript = obj.GetComponent<InteractionBase> ()) != null) {
				m_Halo.SwitchHalo (obj);
				//Gestion des entrées de l'utilisateur
				CheckInputs (objScript);
			}
			//Sinon, on s'assure que le halo n'est pas affiché
			else {
				m_Halo.RemoveHalo ();
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
		if (Input.GetMouseButtonDown (0)) {
			UnityAction observe;
			if (interactions.TryGetValue (InteractionType.Observe, out observe))
				observe.Invoke ();
		}
		//Bouton droit pressé, utilisation
		else if (Input.GetMouseButtonDown (1)) {
			UnityAction use;
			if(interactions.TryGetValue(InteractionType.Use, out use))
				use.Invoke ();
		}
	}

	/**
	 * Dessine un rayon entre le joueur et l'endroit où il regarde
	 * @param hitPoint Point touché
	 */
	private void DrawRaycast(Vector3 hitPoint) {
		m_Line.enabled = true;
		m_Line.SetPosition (0, transform.position);
		m_Line.SetPosition (1, hitPoint);
	}
}
