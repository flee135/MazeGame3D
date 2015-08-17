using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Constants {

	public static int startingMazeSize = 10;
	public static int countdownTime = 3;

	public static string playerName = "Player";
	public static string portalName = "Portal";
	public static string portalPrefabDest = "Prefabs/Portal";
	public static string portalKeyName = "PortalKey";
	public static string portalKeyPrefabDest = "Prefabs/PortalKey";
	public static string groundName = "Board";
	public static string mazeWallsName = "Maze Walls";

	// The following are just global variables that can and should be modified.
	public static bool isPaused = false;
	public static bool isCountingDown = true;
	public static List<float> times = new List<float>();

}
