using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSystem : MonoBehaviour {

	Animator anim;
	public Transform Player;
	private float Distance;
//	Quaternion m_lookAtRotation;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

	//	Distance = Vector3.Distance(Player.position, transform.position);
		float Dist = Player.transform.position.x - transform.position.x;
		float Distance = Mathf.Abs (Dist);

		if (Distance < 20) {
			transform.LookAt (Player);
			anim.SetBool ("Waving_b", true);

			if (Distance < 10 && Distance > 3.5) {
			
				anim.SetBool ("Waving_b", false);
				anim.SetFloat ("Speed_f", 1);
				//transform.Translate (Vector3(0,0,0.05));
				transform.position += transform.forward * Time.deltaTime * 2;
			}

		} else {
			anim.SetBool ("Waving_b", false);
			anim.SetFloat ("Speed_f", 0);
		}

	}
}
