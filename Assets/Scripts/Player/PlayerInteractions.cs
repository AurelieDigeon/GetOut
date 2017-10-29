using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Ce script gère les interactions du joueur principal, y compris le ray-casting.
 */
public class PlayerInteractions : MonoBehaviour {
	/**
	 * Caméra depuis laquelle lancer le raycasting
	 */
	private Camera m_Camera;

	/**
	 * Rendu du RayCasting
	 */
	private LineRenderer m_Line;

	void Start() {
		m_Camera = Camera.main;
		m_Line = GetComponent<LineRenderer> ();
		m_Line.enabled = false;
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
