using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PortalTriggerBehavior : MonoBehaviour {

	public Material portalActiveMaterial;
	public Material portalInactiveMaterial;
	public AudioClip teleportSound;

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
			AudioSource.PlayClipAtPoint(teleportSound, gameObject.transform.position);
			Logic.setupRun (MazeGenerator.currentSize);
			setIsActive (false);

			// Add time of run to list of times
			GameObject player = GameObject.Find (Constants.playerName);
			if (player != null) {
				PlayerHUDScript hud = (PlayerHUDScript)player.GetComponent (typeof(PlayerHUDScript));
				Constants.times.Add (hud.timer);
				hud.totalTime += hud.timer;
				hud.updateRunningTimes ();
			}
		}
	}
}
