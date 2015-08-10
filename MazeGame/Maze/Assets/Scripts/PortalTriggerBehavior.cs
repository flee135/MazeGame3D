using UnityEngine;
using System.Collections;

public class PortalTriggerBehavior : MonoBehaviour {

	public Material portalActiveMaterial;
	public Material portalInactiveMaterial;

	bool isActive;

	void Start() {
		setIsActive (false);
	}

	public void setIsActive(bool isActive) {
		this.isActive = isActive;
		if (isActive) {
			this.gameObject.GetComponent<Renderer>().material = portalActiveMaterial;
			ParticleSystem particleSystem = this.GetComponentInChildren<ParticleSystem>();
			particleSystem.startColor = Color.green;
		} else {
			this.gameObject.GetComponent<Renderer>().material = portalInactiveMaterial;
			ParticleSystem particleSystem = this.GetComponentInChildren<ParticleSystem>();
			particleSystem.startColor = Color.red;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (isActive) {
			MazeGenerator.resetMaze (MazeGenerator.currentSize);
			setIsActive (false);
		}
	}
}
