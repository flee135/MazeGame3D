using UnityEngine;
using System.Collections;

public class CubeSpin : MonoBehaviour {

	public float spinSpeed;
	public float floatingSpeed;
	public float floatingDistance;

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up, spinSpeed*10*Time.deltaTime, Space.World);
	}


}
