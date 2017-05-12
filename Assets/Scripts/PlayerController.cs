using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	float speed = 7.0f;
	float jumpSpeed = 5.0F;
	float gravity = 2.0F;

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	private Text levelTitle;
	private Text levelText;
	private GameObject levelImage;
	private Vector3 moveDirection = Vector3.zero;
	private Timer timerScript;

	void Awake (){
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
		if (SceneManager.GetActiveScene().buildIndex != 0) {
			levelImage = GameObject.Find ("LevelImage");
			levelTitle = GameObject.Find ("PopupTitle").GetComponent<Text>();
			levelText = GameObject.Find ("PopupText").GetComponent<Text>();
			timerScript = GameObject.Find("Player").GetComponent <Timer> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene().buildIndex != 0) {
			transform.Rotate(0,Input.GetAxis("Rotate")*60*Time.deltaTime,0);
			CharacterController controller = GetComponent<CharacterController>();
			if (controller.isGrounded) {
				moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;
				if (Input.GetButton("Jump"))
					moveDirection.y = jumpSpeed;

			}
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);
			float h = Input.GetAxisRaw ("Horizontal");
			float v = Input.GetAxisRaw ("Vertical");
			bool checkingtime = Input.GetKey (KeyCode.Space);
			bool waving = Input.GetKey (KeyCode.LeftShift);

			if (checkingtime == true) {
				//Move (0, 0);
				CTAnimation ();
			}
			else if (waving == true) {
				WaveAnimation ();
				//Move (h, v);
			}
			else {
				//Move (h, v);
				Animating (h, v);
				anim.SetBool ("Checktime_b", false);
				anim.SetBool ("Waving_b", false);
			}
		}
	}

	void Move(float h, float v){
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.position + movement);
	}

	IEnumerator Rotate( Vector3 axis, float angle, float duration = 1.0f)
	{
		Quaternion from = transform.rotation;
		Quaternion to = transform.rotation;
		to *= Quaternion.Euler( axis * angle );

		float elapsed = 0.0f;
		while( elapsed < duration )
		{
			transform.rotation = Quaternion.Slerp(from, to, elapsed / duration );
			elapsed += Time.deltaTime;
			yield return null;
		}
		transform.rotation = to;
	}

	void Animating (float h, float v){
		if (h != 0f || v != 0f) {
			anim.SetFloat ("Speed_f", 7.0f);
		} 
		else {
			anim.SetFloat ("Speed_f", 0);
		}
	}

	void CTAnimation (){
		anim.SetBool ("Checktime_b", true);
	}

	void WaveAnimation(){
		anim.SetBool ("Waving_b", true);
	}
	void DisplayWin() {
		timerScript.freeze = true;
		levelTitle.text = "";
		levelText.text = "Wow good job!";
		levelImage.SetActive(true);
	}
	void LoadNextLevel() {
		int x = SceneManager.GetActiveScene().buildIndex + 1;
		levelTitle.text = "";

		if (x < 6) {
			levelText.text = "Loading next level\nplease wait :)";
			levelImage.SetActive (true);
			Application.LoadLevel (x);
		} else {
			levelText.text = "Wow! You successfully survive in HKU! Congrats!!!!!!!!! XD";
			levelImage.SetActive (true);
		}
	}
	void OnTriggerEnter(Collider other) {
		if (other.name == "EndingCube" || other.name == "EndingCube_2") {
			DisplayWin ();
			Invoke ("LoadNextLevel", 4f);
		}
		if (other.gameObject.CompareTag ("Apple"))
		{
			speed = 20f;
			Invoke ("Slowdown", 3.0f);
		}
	}

	private void Slowdown(){
		speed = 7.0f;
	}
}
