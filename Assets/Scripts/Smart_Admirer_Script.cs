using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smart_Admirer_Script : MonoBehaviour {

	GameObject Destination;
	UnityEngine.AI.NavMeshAgent nav;
	Animator anim;
	bool destinationInRange = false;
	int[] moves = {1,2,3,4};
	int Animation_decision = 5;

	void Awake () {
		Destination = GameObject.FindGameObjectWithTag ("Shirley_Gathering_Point");
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		anim = GetComponent <Animator> ();
		Animation_decision = moves[Random.Range (0, 4)];
		anim = GetComponent <Animator> ();
	}
	

	void Update () {
		nav.SetDestination (Destination.transform.position);

		if (destinationInRange == true) {
			nav.Stop();
			anim.SetFloat ("Speed_f", 0);

		} else {
			anim.SetFloat ("Speed_f", 10);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == Destination) {
			destinationInRange = true;
			if (Animation_decision == 1) {
				anim.SetBool ("Waving_b", true);
			} else if (Animation_decision == 2) {
				anim.SetBool ("Standingjump_b", true);
			} else if (Animation_decision == 3) {
				anim.SetBool ("Sexydance_b", true);
			} else if (Animation_decision == 4) {
				anim.SetBool ("Smoking_b", true);
			}
		}

	}
}
