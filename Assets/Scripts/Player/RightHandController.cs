using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.Events;

public class RightHandController : MonoBehaviour {
	/**
	 * Mémoire de l'objet avec lequel on est actuellement en collision
	 */
	InteractionBase collisionWith = null;

	/**
	 * Indique si l'objet avec lequel on est en collision est attrapé
	 */
	bool grabbed = false;
	void FixedUpdate() {
		float button = Input.GetAxis ("Fire2");
		//Si on touche un objet
		if (collisionWith) {
			//Tentative d'attraper l'objet : on vérifie qu'il n'est pas déjà attrapé
			if (button > 0 && !grabbed) {
				UnityAction take;
				if (collisionWith.GetInteractions (gameObject).TryGetValue (InteractionType.Take, out take)) {
					take.Invoke ();
					grabbed = true;
				}
			} 
		}

		//Relâchement de l'objet : s'il est parti ou a été volontairement relâché
		if (button == 0) {
			var fxs = GetComponents<FixedJoint> ();
			foreach (var fx in fxs) {
				fx.connectedBody = null;
				Destroy (fx);
			}
		}
	}

	void Update () {
		//Position de la manette
		Vector3 handPosition = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.RightHand);
		Vector3 headPosition = UnityEngine.XR.InputTracking.GetLocalPosition (UnityEngine.XR.XRNode.Head);
		//On change la position en maintenant l'offset réel entre tête et main
		transform.position = Camera.main.transform.position - (headPosition - handPosition) * 1.3f + new Vector3(0, 0, 0);

		//On maintient également la rotation
		Vector3 rotAngles = UnityEngine.XR.InputTracking.GetLocalRotation (UnityEngine.XR.XRNode.RightHand).eulerAngles + new Vector3 (90, 0, 0);
		transform.rotation = Quaternion.Euler(rotAngles);
	}

	void OnTriggerEnter(Collider col) {
		GameObject other = col.gameObject;
		InteractionBase inter;
		//On collide avec un objet interactible
		if ((inter = other.GetComponent<InteractionBase> ()) != null) {
			collisionWith = inter;
			grabbed = false;
			UnityAction use;
			if (inter.GetInteractions(gameObject).TryGetValue(InteractionType.Use, out use)) {
				use.Invoke ();
			}
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.GetComponent<InteractionBase> () != null) {
			collisionWith = null;
			grabbed = false;
		}
	}
}
