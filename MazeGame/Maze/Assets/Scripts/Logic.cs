using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class Logic : MonoBehaviour {

	public static void setupRun(int size) {
		MazeGenerator.resetMaze (size);
		
		GameObject player = GameObject.Find (Constants.playerName);
		if (player != null) {
			FirstPersonController ctrl = (FirstPersonController)player.GetComponent (typeof(FirstPersonController));
			ctrl.enabled = false;
			PlayerHUDScript hud = (PlayerHUDScript)player.GetComponent (typeof(PlayerHUDScript));
			hud.startCountdown (Constants.countdownTime);
		}
	}
}
