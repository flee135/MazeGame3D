using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class PlayerHUDScript : MonoBehaviour {

	public float timer;
	public Text timerText;
	public float endCountdownTime;

	private bool countingDown;

	// Use this for initialization
	void Start () {
		timer = 0f;
		countingDown = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (countingDown) {
			if (Time.time < endCountdownTime) {
				timer = endCountdownTime-Time.time;
				updateTimerText ();
			}
			else {
				timer = 0f;
				setTimerTextColor (new Color (0, 0, 0));
				countingDown = false;
				gameObject.GetComponentInParent<FirstPersonController>().enabled = true;
			}
		} else {
			timer += Time.deltaTime;
			updateTimerText ();
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
		endCountdownTime = Time.time + seconds;
		countingDown = true;
		setTimerTextColor (new Color (255, 0, 0));
	}

	public void setTimerTextColor (Color color) {
		timerText.color = color;
	}
}
