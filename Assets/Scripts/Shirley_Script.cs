using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shirley_Script : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Awake () {
		anim = GetComponent <Animator> ();

		anim.SetBool ("Waving_b", true);
	}

}
