using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class PlayerHUDScript : MonoBehaviour {

	public float timer;
	public float countdownTimer;
	public Text timerText;

	// Use this for initialization
	void Start () {
		timer = 0f;
		countdownTimer = 0f;
		Constants.isCountingDown = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!Constants.isPaused) {
			if (Constants.isCountingDown) {
				countdownTimer += Time.deltaTime;
				if (countdownTimer < Constants.countdownTime) {
					timer = Constants.countdownTime-countdownTimer;
					updateTimerText ();
				} else {
					timer = 0f;
					setTimerTextColor (Color.black);
					Constants.isCountingDown = false;
					gameObject.GetComponentInParent<FirstPersonController> ().enabled = true;
				}
			} else {
				timer += Time.deltaTime;
				updateTimerText ();
			}
		}
	}

	void updateTimerText() {
		int minutes = Mathf.FloorToInt(timer / 60f);
		int seconds = Mathf.FloorToInt(timer - minutes * 60);
		int millis = Mathf.FloorToInt((timer - minutes*60 - seconds)*1000);
		
		timerText.text = string.Format("{0:0}:{1:00}.{2:000}", minutes, seconds, millis);
	}

	public void resetTimer() {
		timer = 0f;
	}

	public void startCountdown(int seconds) {
		countdownTimer = 0f;
		Constants.isCountingDown = true;
		setTimerTextColor (Color.red);
	}

	public void setTimerTextColor (Color color) {
		timerText.color = color;
	}
}
