using UnityEngine;
using System.Collections;

public class MazeControllerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MazeGenerator.drawMaze (10);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Alpha1)) {
			MazeGenerator.resetMaze (5);
		} else if (Input.GetKey (KeyCode.Alpha2)) {
			MazeGenerator.resetMaze (10);
		} else if (Input.GetKey (KeyCode.Alpha3)) {
			MazeGenerator.resetMaze (15);
		} else if (Input.GetKey (KeyCode.Alpha4)) {
			MazeGenerator.resetMaze (20);
		}
	}
}
