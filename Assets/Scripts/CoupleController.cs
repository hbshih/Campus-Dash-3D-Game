using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupleController : MonoBehaviour {

	Animator anim;

	void Awake () {
		anim = GetComponent <Animator> ();
	
	}

	// Update is called once per frame
	void Update () {
			anim.SetFloat ("Speed_f", 1);
	}
}
