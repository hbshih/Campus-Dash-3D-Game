﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waving_AIController : MonoBehaviour {

	GameObject ATM, ChiWah_1, ChiWah_2, ChiWah_3, MTR, Centennial, CYC, SU, HakingWong, SU_2, Lib;
	UnityEngine.AI.NavMeshAgent nav;
	Animator anim;
	bool destinationInRange = false;
	Transform ObjectDestination;
	float speed = 0;
	int timer = 0;
	int duration = 0;
	bool stop = false;
	Transform spawnPoint;
	int spawnPointTag;

	void Awake () {
		ATM = GameObject.FindGameObjectWithTag ("ATM_Destination");
		ChiWah_1 = GameObject.FindGameObjectWithTag ("ChiWah_Destination");
		ChiWah_2 = GameObject.FindGameObjectWithTag ("ChiWah2_Destination");
		ChiWah_3 = GameObject.FindGameObjectWithTag ("ChiWah3_Destination");
		MTR = GameObject.FindGameObjectWithTag ("MTR_Destination");
		Centennial = GameObject.FindGameObjectWithTag ("Centennial_Destination");
		CYC = GameObject.FindGameObjectWithTag ("CYC_Destination");
		HakingWong = GameObject.FindGameObjectWithTag ("HW_Destination");
		SU = GameObject.FindGameObjectWithTag ("SU_Destination");
		SU_2 = GameObject.FindGameObjectWithTag ("SU2_Destination");
		Lib = GameObject.FindGameObjectWithTag ("Lib_Destination");
		Transform[] destination = { ATM.transform, ChiWah_1.transform, ChiWah_2.transform, ChiWah_3.transform, MTR.transform, Centennial.transform, 
			CYC.transform, HakingWong.transform, SU.transform, SU_2.transform, Lib.transform};
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		anim = GetComponent <Animator> ();
		ObjectDestination = destination[Random.Range (0, 11)];
		speed = Random.Range (1, 15);
		nav.SetDestination (ObjectDestination.position);
		spawnPoint = AI_Spawn.chosenPoint;
	}

	// Update is called once per frame
	void Update () {

		if (destinationInRange == false) {
			if (stop == false) {
				int random = Random.Range (0, 240);
				duration = Random.Range (48, 120);
				if (random > 238) {
					stop = true;
					anim.SetFloat ("Speed_f", 0);
					if (Random.Range (0, 3) == 0) {
						anim.SetBool ("Checktime_b", true);
					} else {
						anim.SetBool ("Waving_b", true);
					}
					nav.Stop (true);
				} else {
					timer = 0;
					stop = false;
					anim.SetFloat ("Speed_f", speed);
					anim.SetBool ("Checktime_b", false);
					anim.SetBool ("Waving_b", false);

					nav.Resume ();
				} 
			} else if (stop == true && timer > duration){
				duration = 0;
				timer = 0;
				stop = false;
				anim.SetFloat ("Speed_f", speed);
				anim.SetBool ("Checktime_b", false);
				anim.SetBool ("Waving_b", false);
				nav.Resume ();
			} else {
				timer = timer + 1;
				//anim.SetFloat ("Speed_f", speed);
			}
		} 
		else {
			anim.SetFloat ("Speed_f", 0);
			DestroyImmediate (gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		
		if(other.gameObject == ChiWah_1 || other.gameObject == ChiWah_2 || other.gameObject == ChiWah_3 || other.gameObject == ATM || 
			other.gameObject == MTR || other.gameObject == Centennial || other.gameObject == CYC || other.gameObject == HakingWong || other.gameObject == SU || other.gameObject == SU_2
			|| other.gameObject == Lib)
			
		{
			destinationInRange = true;
		}

/*		for (int i = 0; i < destination_array.Length; i++) 
		{	
			if (other.gameObject == destination_array [i]) 
			{
				destinationInRange = true;
			}
		}
*/
	}

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == ObjectDestination)
		{
			destinationInRange = false;
		}
	}
}
