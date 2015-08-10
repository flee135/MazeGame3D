using UnityEngine;
using System.Collections;

public class InventoryScript : MonoBehaviour {

	public bool hasCube;

	// Use this for initialization
	void Start () {
		hasCube = false;
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.name.Equals ("PortalKey(Clone)")) {
			GameObject.Destroy (hit.gameObject);
			hasCube = true;
			GameObject portal = GameObject.Find ("Portal");
			PortalTriggerBehavior portalScript = (PortalTriggerBehavior) portal.GetComponent(typeof(PortalTriggerBehavior));
			portalScript.setIsActive(true);
		}
	}
}
