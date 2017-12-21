using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlickeringLightController : MonoBehaviour {

	//Material duquel controller l'émission
	public Material mat;

	//Indique si on doit continuer de clignoter
	private bool again = true;

	// the (comparatively) steady light phase
	public float minLightMs =  50;
	public float maxLightMs =  100;

	// dark part of the flicker phase:
	public float minDarkMs  =    300;
	public float maxDarkMs  =    600;

	// the time between flickers in the dark phase:
	public float minFlickMs  =    25;
	public float maxFlickMs  =    50;

	// number of times to flicker during the dark phase:
	public int minFlicks    =     1;
	public int maxFlicks    =     10;

	// internal reference to the light component
	private Light _light;

	void Start () {
		_light = GetComponent<Light>();
		StartCoroutine("Flicker");

		EventManager.StartListening ("StopFlickering", new UnityAction (StopFlicker));
	}

	IEnumerator Flicker () {
		while (again) {
			// steady light period
			_light.enabled = true;
			mat.EnableKeyword ("_EMISSION");
			yield return new WaitForSeconds(Random.Range(minLightMs, maxLightMs)/1000f);
			// flickering light period
			for (int i = 0; i < Random.Range (minFlicks, maxFlicks); i++) {
				_light.enabled = false;
				mat.DisableKeyword ("_EMISSION");
				yield return new WaitForSeconds(Random.Range(minDarkMs, maxDarkMs)/1000f);
				_light.enabled = true;
				mat.EnableKeyword ("_EMISSION");
				yield return new WaitForSeconds(Random.Range(minFlickMs, maxFlickMs)/1000f);
			}
		}
	}

	public void StopFlicker() {
		again = false;
	}
}
