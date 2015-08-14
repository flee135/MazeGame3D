using UnityEngine;
using System.Collections;

public class BoardScript : MonoBehaviour {

	void Start() {
		Logic.setupRun (MazeGenerator.currentSize);
	}

	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			// For now, exit to main menu
			Application.LoadLevel (0);
		}
	}
}
