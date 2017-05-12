using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandpaScript : MonoBehaviour 
{
	public GameObject grandma;
	UnityEngine.AI.NavMeshAgent nav;
	Animator anim;
	bool grandmagone = false;

	private Vector3 offset;

	void Start()
	{
		grandma = GameObject.FindGameObjectWithTag ("Grandma");
		offset = transform.position - grandma.transform.position;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		anim = GetComponent <Animator> ();
	}

	void LateUpdate()
	{
		nav.SetDestination (grandma.transform.position+offset);
		anim.SetFloat ("Speed_f", 1);
	}
}
