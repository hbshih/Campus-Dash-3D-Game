using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformFollower : MonoBehaviour {

	public GameObject player;

	[SerializeField]
	private Transform target;

	[SerializeField]
	private Vector3 offsetPosition;

	[SerializeField]
	private Space offsetPositionSpace = Space.Self;

	[SerializeField]
	private bool lookAt = true;

	/*
	void Start()
	{
		offsetPosition = transform.position - player.transform.position;
	}
	*/

	private void Update()
	{
		Refresh();
	}

	public void Refresh()
	{
		if(target == null)
		{
			Debug.LogWarning("Missing target ref !", this);

			return;
		}

		// compute position
		if(offsetPositionSpace == Space.Self)
		{
			transform.position = target.TransformPoint(offsetPosition);
		}
		else
		{
			transform.position = target.position + offsetPosition;
		}

		// compute rotation
		if(lookAt)
		{
			transform.LookAt(target);
			//transform.rotation = target.rotation;
		}
		else
		{
			transform.rotation = target.rotation;
		}
	}
}
