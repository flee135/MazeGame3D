using UnityEngine;
using System.Collections;

public class PlayerInventoryScript : MonoBehaviour {

	public bool hasCube;
	public AudioClip collectAudio;

	// Use this for initialization
	void Start () {
		hasCube = false;
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.name.Equals (Constants.portalKeyName)) {
			AudioSource.PlayClipAtPoint(collectAudio, gameObject.transform.position);
			GameObject.Destroy (hit.gameObject);
			hasCube = true;
			GetComponent<PlayerHUDScript>().setTimerTextColor (Color.green);
			GameObject portal = GameObject.Find (Constants.portalName);
			PortalTriggerBehavior portalScript = (PortalTriggerBehavior) portal.GetComponent(typeof(PortalTriggerBehavior));
			portalScript.setIsActive(true);
		}
	}
}
