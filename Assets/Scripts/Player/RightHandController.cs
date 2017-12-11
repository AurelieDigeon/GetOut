using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.Events;

public class RightHandController : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		Vector3 handPosition = InputTracking.GetLocalPosition(VRNode.RightHand);
		Vector3 headPosition = InputTracking.GetLocalPosition (VRNode.CenterEye);
		transform.position = Camera.main.transform.position - (headPosition - handPosition);
		Vector3 rotAngles = InputTracking.GetLocalRotation (VRNode.RightHand).eulerAngles + new Vector3 (90, 0, 0);
		transform.rotation = Quaternion.Euler(rotAngles);
	}

	void OnCollisionEnter(Collision col) {
		GameObject other = col.gameObject;
		InteractionBase inter;
		if ((inter = other.GetComponent<InteractionBase> ()) != null) {
			UnityAction use;
			if (inter.GetInteractions(gameObject).TryGetValue(InteractionType.Use, out use)) {
				use.Invoke ();
			}
		}
	}
}
