using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class PlayerHUDScript : MonoBehaviour {

	public float totalTime;
	public float timer;
	public float countdownTimer;

	public Text timerText;
	public Text avgText;
	public Text runtime1;
	public Text runtime2;
	public Text runtime3;

	// Use this for initialization
	void Start () {
		timer = 0f;
		totalTime = 0f;
		countdownTimer = 0f;
		Constants.isCountingDown = true;

		avgText.text = "Average: N/A";
		runtime1.text = "N/A";
		runtime2.text = "N/A";
		runtime3.text = "N/A";
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

	public void startCountdown(int seconds) {
		countdownTimer = 0f;
		Constants.isCountingDown = true;
		setTimerTextColor (Color.red);
	}

	public void setTimerTextColor (Color color) {
		timerText.color = color;
	}

	public void updateRunningTimes() {
		float avgTime = totalTime / Constants.times.Count;
		int minutes = Mathf.FloorToInt(avgTime / 60f);
		int seconds = Mathf.FloorToInt(avgTime - minutes * 60);
		int millis = Mathf.FloorToInt((avgTime - minutes*60 - seconds)*1000);
		avgText.text = string.Format ("Average: {0:0}:{1:00}.{2:000}", minutes, seconds, millis);

		if (Constants.times.Count > 0) {
			float time = Constants.times[Constants.times.Count-1];
			minutes = Mathf.FloorToInt(time / 60f);
			seconds = Mathf.FloorToInt(time - minutes * 60);
			millis = Mathf.FloorToInt((time - minutes*60 - seconds)*1000);
			runtime1.text = string.Format ("{0:0}:{1:00}.{2:000}", minutes, seconds, millis);
		}

		if (Constants.times.Count > 1) {
			float time = Constants.times[Constants.times.Count-2];
			minutes = Mathf.FloorToInt(time / 60f);
			seconds = Mathf.FloorToInt(time - minutes * 60);
			millis = Mathf.FloorToInt((time - minutes*60 - seconds)*1000);
			runtime2.text = string.Format ("{0:0}:{1:00}.{2:000}", minutes, seconds, millis);
		}

		if (Constants.times.Count > 2) {
			float time = Constants.times[Constants.times.Count-3];
			minutes = Mathf.FloorToInt(time / 60f);
			seconds = Mathf.FloorToInt(time - minutes * 60);
			millis = Mathf.FloorToInt((time - minutes*60 - seconds)*1000);
			runtime3.text = string.Format ("{0:0}:{1:00}.{2:000}", minutes, seconds, millis);
		}
	}
}
