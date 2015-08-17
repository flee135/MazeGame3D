using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;
using System.Collections.Generic;

public class MazeUI : MonoBehaviour {

	public Canvas escapeMenu;
	public Text exitText;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			escapeMenu.enabled = !escapeMenu.enabled;
			Constants.isPaused = escapeMenu.enabled;

			GameObject player = GameObject.Find (Constants.playerName);
			if (player != null) {
				FirstPersonController ctrl = (FirstPersonController)player.GetComponent (typeof(FirstPersonController));
				if (escapeMenu.enabled || Constants.isCountingDown) {
					ctrl.enabled = false;
				} else {
					ctrl.enabled = true;
				}
			}
		}
	}

	void Start () {
		escapeMenu = escapeMenu.GetComponent<Canvas> ();
		exitText = exitText.GetComponent<Text> ();
		escapeMenu.enabled = false;
	}

	public void resumePressed() {
		escapeMenu.enabled = false;
		Constants.isPaused = false;

		GameObject player = GameObject.Find (Constants.playerName);
		if (player != null) {
			FirstPersonController ctrl = (FirstPersonController)player.GetComponent (typeof(FirstPersonController));
			ctrl.enabled = true;
		}
	}

	public void exitPressed() {
		Constants.isPaused = false;
		Constants.times = new List<float> ();
		Application.LoadLevel (0);
	}
}
