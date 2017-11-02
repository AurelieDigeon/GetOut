using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Ce script gère les interactions du joueur principal, y compris le ray-casting.
 */
public class PlayerInteractions : MonoBehaviour {
	/**
	 * Prefab contenant le halo de lumière
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
	 * Halo à assigner à un objet
	 */
	private GameObject halo;

	void Start() {
		m_Camera = Camera.main;
		m_Line = GetComponent<LineRenderer> ();
		m_Line.enabled = false;

		halo = Instantiate (HaloPrefab) as GameObject;
		DisableHalo ();
	}

	void Update () {
		CheckForRaycast ();	
	}

	private void CheckForRaycast() {
		//Là où regarde le joueur
		Ray ray = m_Camera.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		//On touche quelque chose avec le Raycast
		if(Physics.Raycast (ray, out hit, Mathf.Infinity)) {
			//Affichage du rayon
			DrawRaycast (hit.point);
			GameObject obj = hit.collider.gameObject;
			//Si l'objet propose des interactions, on affiche un halo
			if (obj.GetComponent<IInteractable> () != null) {
				AddHalo (obj);
			} else {
				DisableHalo ();
			}
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

	/**
	 * Active le halo et change son parent
	 * @param obj Objet concerné
	 */
	private void AddHalo(GameObject obj) {
		//Si l'objet n'a pas déjà de Halo
		if (halo.transform.parent != obj.transform) {
			//Ajout effectif du halo comme enfant relatif de l'objet
			halo.transform.SetParent (obj.transform, false);
		}
		EnableHalo ();
	}

	/**
	 * Désactive le halo
	 */
	private void DisableHalo() {
		Behaviour haloBehaviour = (Behaviour)halo.GetComponent ("Halo");
		haloBehaviour.enabled = false;
	}

	private void EnableHalo() {
		Behaviour haloBehaviour = (Behaviour)halo.GetComponent ("Halo");
		haloBehaviour.enabled = true;
	}
}
