using UnityEngine;
using System.Collections;

public class BoardScript : MonoBehaviour {

	void Start() {
		MazeGenerator.drawMaze (10);
	}
}
