using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

	//public GameObject loadingImage;
	private int thisLevel = 0;
	private GameObject popupWindow;
	private Text popupText;
	private Text popupTitle;

	void Start () {
		popupWindow = GameObject.Find ("PopupImage");
		popupTitle = GameObject.Find ("PopupTitle").GetComponent<Text>();
		popupText = GameObject.Find ("PopupText").GetComponent<Text>();
		popupWindow.SetActive (false);
	}

	public void SetLevel(int level) {
		thisLevel = level;
		if (level == 0) {
			popupWindow.SetActive (false);
		} else {
			if (level == 1) {
				popupTitle.text = "1. Go to Dr. Chim's Lecture";
				popupText.text = "This is your first day in HKU and you are very interested in Dr. Chim's Game Design course. Rush to classroom to get a seat in the front row!";
			}
			else if (level == 2) {
				popupTitle.text = "2. Attend High Table Dinner";
				popupText.text = "You just finished your class at 6:20 but you have high table dinner at Loke Yew Hall at 6:30. Go back to your hall on campus ASAP to get dressed!";
			}
			else if (level == 3) {
				popupTitle.text = "3. DanceSo Dance Practice";
				popupText.text = "A group project meeting ran late. You need to go to dance practice in front of Dance Society booth right now. Otherwise, your seniors will get upset.";
			}
			else if (level == 4) {
				popupTitle.text = "4. Date with Girlfriend";
				popupText.text = "You have been so busy on assignments, hall activities and dance practice these days. Your girlfriend is very pissed. You decide to have a picnic date with her on the grassland on campus before she runs out of control.";
			}
			else if (level == 5) {
				popupTitle.text = "5. Rush to Part-time Tutoring";
				popupText.text = "After half semester, your bank account ran very low. Now you get a chance to do tutoring in mid-levels for 250HKD/hr. Seize the chance!";
			}
			popupWindow.SetActive (true);
		}
	}

	public void LoadScene(){
		//loadingImage.SetActive(true);
		Application.LoadLevel(thisLevel);
	}
	public void LoadThisLevel() {
		Application.LoadLevel(SceneManager.GetActiveScene().buildIndex);
	}
	public void LoadMenu() {
		Application.LoadLevel(0);
	}
}
