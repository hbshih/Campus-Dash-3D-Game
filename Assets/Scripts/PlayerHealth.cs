using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
	
	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public float timeBetweenRecovery = 5f;
	public AudioClip deathClip;
	public bool outOfMap = false;


	Animator anim;
	PlayerController playerController;
	AI_Spawn AISpawn;
	bool damaged;
	float timer;
	int regenerate = 1;
	AudioSource playerAudio;
	bool deadonce = false;
	public Vector3 playerpos;
	bool belowzero = false;
	int count = 0;
	bool isDead;

	// Use this for initialization
	void Awake () {
		anim = GetComponent <Animator> ();
		currentHealth = startingHealth;
		playerController = GetComponent <PlayerController> ();
		AISpawn = GetComponent<AI_Spawn> ();
		playerAudio = GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerpos = GameObject.Find("Player").transform.position;
		if(damaged && deadonce == false)
		{
			damageImage.color = flashColour;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);

			timer += Time.deltaTime;
			if(timer >= timeBetweenRecovery && currentHealth < startingHealth)
			{
				currentHealth = currentHealth + regenerate;
				timer = 0f;
			}
		}
		damaged = false;

		if (playerpos.y <= -5.0) {
			belowzero = true;
			outOfMap = true;
			count++;
		}
		if (belowzero && count == 1) {
			Death ();
		}
	}

	public void TakeDamage (int amount)
	{
		damaged = true;

		timer = 0f;

		currentHealth -= amount;

		healthSlider.value = currentHealth;

		playerAudio.Play ();

		if(currentHealth <= 0 && !isDead && deadonce == false)
		{
			Death ();
		}
	}

	void Death ()
	{
		isDead = true;
		deadonce = true;
		anim.SetTrigger ("Death_b");

		playerAudio.clip = deathClip;
		playerAudio.Play ();

		playerController.enabled = false;
		AISpawn.enabled = false;
		regenerate = -10;
	}


}
