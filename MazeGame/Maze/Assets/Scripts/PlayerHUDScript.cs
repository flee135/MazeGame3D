using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHUDScript : MonoBehaviour {

	public static float timer;
	public Text timerText;

	// Use this for initialization
	void Start () {
		timer = 0f;
		updateTimerText ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		updateTimerText ();
	}

	void updateTimerText() {
		int minutes = Mathf.FloorToInt(timer / 60f);
		int seconds = Mathf.FloorToInt(timer - minutes * 60);
		int millis = Mathf.FloorToInt((timer - minutes*60 - seconds)*1000);
		
		timerText.text = string.Format("{0:0}:{1:00}.{2:000}", minutes, seconds, millis);
	}
}
