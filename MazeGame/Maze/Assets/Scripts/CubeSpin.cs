using UnityEngine;
using System.Collections;

public class CubeSpin : MonoBehaviour {

	public float speed;

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up, speed*10*Time.deltaTime, Space.World);
	}
}
