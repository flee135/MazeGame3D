using UnityEngine;
using System.Collections;

public class PortalTriggerBehavior : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		MazeGenerator.resetMaze (MazeGenerator.currentSize);
		//MazeControllerScript s = other.gameObject.GetComponent<MazeControllerScript> ();
		//print ("collisionasdjflkasjdf");
		//s.Invoke("drawMaze(10)", 0);
	}
}
