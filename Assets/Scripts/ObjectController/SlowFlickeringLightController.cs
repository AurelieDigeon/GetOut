﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowFlickeringLightController : MonoBehaviour {

	// Your light gameObject here.
	private Light lightning;

 	// Array of random values for the intensity.
	private float[] smoothing = new float[10];

 void Start(){
	 lightning = this.GetComponent<Light>();
   // Initialize the array.
   for(int i = 0 ; i < smoothing.Length ; i++){
       smoothing[i] = .0f;
   }
 }

 void Update () {
   float sum = .0f;

   // Shift values in the table so that the new one is at the
   // end and the older one is deleted.
   for(int i = 1 ; i < smoothing.Length ; i++)
   {
       smoothing[i-1] = smoothing[i];
       sum+= smoothing[i-1];
   }

   // Add the new value at the end of the array.
   smoothing[smoothing.Length -1] = Random.value;
   sum+= smoothing[smoothing.Length -1];

   // Compute the average of the array and assign it to the
   // light intensity.
   lightning.intensity = sum / smoothing.Length;
 }
}
