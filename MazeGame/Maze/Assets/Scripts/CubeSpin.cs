using UnityEngine;
using System.Collections;

public class CubeSpin : MonoBehaviour {

	public float spinSpeed;
	public float floatingSpeed;
	public float floatingDistance;

	void Awake() {
		//StartCoroutine ("LoopFloating");
	}

	IEnumerator LoopFloating() {
		float dir = 1f;
		print (1);
		while (true) {
			print (2);
			while (Mathf.Abs (transform.position.y - 1.5f) < floatingDistance) {
				print (3);
				float dy = Time.deltaTime * floatingSpeed;
				transform.position = new Vector3(transform.position.x, transform.position.y+dy*dir, transform.position.z);
				print (4);
				yield return null;
			}
			print (5);
			dir *= -1;
		}
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up, spinSpeed*10*Time.deltaTime, Space.World);
	}


}
