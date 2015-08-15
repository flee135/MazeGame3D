using UnityEngine;
using System.Collections;

public class BoardScript : MonoBehaviour {

	void Start() {
		Logic.setupRun (MazeGenerator.currentSize);
	}
}
