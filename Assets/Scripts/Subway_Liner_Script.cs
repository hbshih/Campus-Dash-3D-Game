using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subway_Liner_Script : MonoBehaviour {

	GameObject Destination;
	UnityEngine.AI.NavMeshAgent nav;
	Animator anim;
	bool destinationInRange = false;
	int position;
	string destinationtag;
	int chosenmove;

	// Use this for initialization
	void Awake () {
		position = SubwaySpawn.lineposition;
		destinationtag = "Subway" + position;
		Destination = GameObject.FindGameObjectWithTag (destinationtag);
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		anim = GetComponent <Animator> ();
		chosenmove = Random.Range (0, 10);
	}
	
	// Update is called once per frame
	void Update () {
		nav.SetDestination (Destination.transform.position);

		if (destinationInRange == true) {
			nav.Stop ();
			anim.SetFloat ("Speed_f", 0);
			if (chosenmove == 2) {
				anim.SetBool ("Lean_b", true);
			}
			if (chosenmove == 3) {
				anim.SetBool ("Smoking_b", true);
			}
			if (chosenmove == 6) {
				anim.SetBool ("Sit_b", true);
			}
			if (chosenmove == 4) {
				anim.SetBool ("Checktime_b", true);
			}

		} else if (destinationInRange == false) {
			nav.SetDestination (Destination.transform.position);
			anim.SetFloat ("Speed_f", 10);
		} else {
			anim.SetFloat ("Speed_f", 10);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == Destination) {
			destinationInRange = true;
		}

	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == Destination) {
			destinationInRange = true;
		}
	}
		
}
