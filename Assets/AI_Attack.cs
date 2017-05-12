using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Attack : MonoBehaviour {
	
	public float timeBetweenAttacks = 5f;
	public int attackDamage = 5;

	Animator anim;
	GameObject player;
	PlayerHealth playerHealth;
	bool playerInRange;
	float timer;
	private Timer timerScript;
	// Use this for initialization

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		anim = GetComponent <Animator> ();
		timerScript = GameObject.Find("Player").GetComponent <Timer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && playerInRange)
		{
			Attack ();
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = false;
		}
	}

	void Attack ()
	{
		timer = 0f;

		if(playerHealth.currentHealth > 0 && !timerScript.freeze)
		{
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
