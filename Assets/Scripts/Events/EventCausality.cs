using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCausality : MonoBehaviour {
	void Awake () {
		EventManager.AddCausality ("UseTrapdoorSwitch", "OpenTrapdoor");
		Debug.Log ("Added UseTrapdoorSwitch -> OpenTrapdoor causality");
		EventManager.AddCausality ("SpecialBookUsed", "PaperFall");
		Debug.Log ("Added SpecialBookUsed -> PaperFall causality");
	}
}
