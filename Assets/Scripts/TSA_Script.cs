using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSA_Script : MonoBehaviour {

	int[] moves = {1,2,3,4};
	int Animation_decision = 5;
	Animator anim;

	void Awake () {
		Animation_decision = moves[Random.Range (0, 4)];
		anim = GetComponent <Animator> ();
		if (Animation_decision == 1) {
			anim.SetBool ("Waving_b", true);
		} else if (Animation_decision == 2) {
			anim.SetBool ("Waving_b", true);
		} else if (Animation_decision == 3) {
			anim.SetBool ("Smoking_b", true);
		} else if (Animation_decision == 4) {
			anim.SetBool ("Smoking_b", true);
		}
	}
}