using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLightController : MonoBehaviour {

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
		}

		IEnumerator Flicker () {
			while (true) {
				// steady light period
				_light.enabled = true;
				yield return new WaitForSeconds(Random.Range(minLightMs, maxLightMs)/1000f);
				// flickering light period
				for (int i = 0; i < Random.Range (minFlicks, maxFlicks); i++) {
					_light.enabled = false;
					yield return new WaitForSeconds(Random.Range(minDarkMs, maxDarkMs)/1000f);
					_light.enabled = true;
					yield return new WaitForSeconds(Random.Range(minFlickMs, maxFlickMs)/1000f);
				}
			}
		}
}
