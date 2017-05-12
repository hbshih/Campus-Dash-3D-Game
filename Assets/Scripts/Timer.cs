using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
	public float levelStartDelay = 5f;
	public Slider healthSlider;
	public Text GameTimer;
	public bool freeze = true;

	//private GameObject Player;
	private Text levelTitle;
	private Text levelText;
	private GameObject levelImage;
	private GameObject goButton;
	private GameObject exitButton;
	private GameObject tryAgainButton;
	private PlayerHealth playerHealth;
	private float timeLeft = 300.0f;
	private int gameOver = 0;
	// Use this for initialization
	void Start () {
		//Player = GameObject.Find ("Player");
		int s = Mathf.FloorToInt (timeLeft % 60F);
		int m = Mathf.FloorToInt (timeLeft / 60F);
		//GameTimer.text = m + ":" + s;
		string display = string.Format ("{0:00} : {1:00}", m, s);
		GameTimer.text = display;
		InitGame ();
	}
	/*private void OnLevelWasLoaded(int index) {
		level++;
		InitGame();
	}*/
	void InitGame() {
		int level = SceneManager.GetActiveScene ().buildIndex;
		if (level != 0) {
			playerHealth = GameObject.Find("Player").GetComponent <PlayerHealth> ();
			levelImage = GameObject.Find ("LevelImage");
			levelTitle = GameObject.Find ("PopupTitle").GetComponent<Text>();
			levelText = GameObject.Find ("PopupText").GetComponent<Text>();
			goButton = GameObject.Find ("GoButton");
			exitButton = GameObject.Find ("ExitButton");
			tryAgainButton = GameObject.Find ("TryAgainButton");
			if (level == 1) {
				timeLeft = 90;
				levelTitle.text = "1. Go to Dr. Chim's Lecture";
				levelText.text = "This is your first day in HKU and you are very interested in Dr. Chim's Game Design course. Rush to classroom to get a seat in the front row!";
			}
			else if (level == 2) {
				timeLeft = 60;
				levelTitle.text = "2. Attend High Table Dinner";
				levelText.text = "You just finished your class at 6:20 but you have high table dinner at Loke Yew Hall at 6:30. Go back to your hall on campus ASAP to get dressed!";
			}
			else if (level == 3) {
				timeLeft = 120;
				levelTitle.text = "3. DanceSo Dance Practice";
				levelText.text = "A group project meeting ran late. You need to go to dance practice in front of Dance Society booth right now. Otherwise, your seniors will get upset.";
			}
			else if (level == 4) {
				timeLeft = 120;
				levelTitle.text = "4. Date with Girlfriend";
				levelText.text = "You have been so busy on assignments, hall activities and dance practice these days. Your girlfriend is very pissed. You decide to have a picnic date with her on the grassland on campus before she runs out of control.";
			}
			else if (level == 5) {
				timeLeft = 180;
				levelTitle.text = "5. Rush to Part-time Tutoring";
				levelText.text = "After half semester, your bank account ran very low. Now you get a chance to do tutoring in mid-levels for 250HKD/hr. Seize the chance!";
			}
			levelImage.SetActive(true);
			goButton.SetActive (true);
			exitButton.SetActive(false);
			tryAgainButton.SetActive(false);
			//Invoke ("HideLevelImage", levelStartDelay);
		}

		int s = Mathf.FloorToInt (timeLeft % 60F);
		int m = Mathf.FloorToInt (timeLeft / 60F);
		//GameTimer.text = m + ":" + s;
		string display = string.Format ("{0:00} : {1:00}", m, s);
		GameTimer.text = display;
	}
	public void HideLevelImage(){
		levelImage.SetActive (false);
		goButton.SetActive (false);
		exitButton.SetActive(true);
		freeze = false;
	}

	private void DisplayDie() {
		levelText.text = "You bumped into too\n many people! :(";
		levelImage.SetActive (true);
		exitButton.SetActive(false);
		tryAgainButton.SetActive(true);
	}
	private void DisplayNoTime() {
		levelText.text = "You are too slow to survive\n in HKU! :(";
		levelImage.SetActive (true);
		exitButton.SetActive(false);
		tryAgainButton.SetActive(true);
	}
	private void DisplayOutOfMap() {
		levelText.text = "Don't commit a suicide!\n HKU loves you! :(";
		levelImage.SetActive (true);
		exitButton.SetActive(false);
		tryAgainButton.SetActive(true);
	}
	private void LoadThisLevel() {
		Application.LoadLevel(SceneManager.GetActiveScene().buildIndex);
	}
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene().buildIndex != 0 && !freeze) {
			if (playerHealth.outOfMap) {
				Invoke ("DisplayOutOfMap", levelStartDelay);
			}
			if (gameOver == 1) {
				Invoke ("DisplayDie", levelStartDelay);
			}
			else if (gameOver == 2) {
				DisplayNoTime ();
			}
			timeLeft -= Time.deltaTime;
			int s = Mathf.FloorToInt (timeLeft % 60F);
			int m = Mathf.FloorToInt (timeLeft / 60F);
			//GameTimer.text = m + ":" + s;
			string display = string.Format ("{0:00} : {1:00}", m, s);
			if (timeLeft >= 0 && healthSlider.value > 0) {
				GameTimer.text = display;
			} else if (healthSlider.value <= 0) {
				gameOver = 1;
			} else {
				gameOver = 2;
			}
		}
	}
}

