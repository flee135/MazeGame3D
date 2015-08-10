using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MazeGenerator {

	const int RAND_RANGE = int.MaxValue;

	public static int currentSize;
	public static Object portalKeyPrefab = (GameObject)Resources.Load (Constants.portalKeyPrefabDest);
	public static Object portalPrefab = (GameObject)Resources.Load (Constants.portalPrefabDest);
	public static GameObject portal;

	static GameObject mazeWalls = new GameObject(Constants.mazeWallsName);

	public static void drawMaze(int size) {
		currentSize = size;

		MazeCell[,] maze = generate (size);

		// Set up ground and outer walls.
		GameObject ground = GameObject.Find (Constants.groundName);
		ground.transform.position = new Vector3 ((float)size*5/2, 0, (float)size*5/2);
		ground.transform.localScale = new Vector3 ((float)size/2, 1, (float)size/2);

		GameObject wallSouth = GameObject.Find ("Wall South");
		wallSouth.transform.position = new Vector3 ((float)size*5/2, 2.5f, 0f);
		wallSouth.transform.localScale = new Vector3 (1f + size*5, 5f, 1f);

		GameObject wallNorth = GameObject.Find ("Wall North");
		wallNorth.transform.position = new Vector3 ((float)size*5/2, 2.5f, (float)size*5);
		wallNorth.transform.localScale = new Vector3 (1f + size*5, 5f, 1f);

		GameObject wallWest = GameObject.Find ("Wall West");
		wallWest.transform.position = new Vector3 (0f, 2.5f, (float)size*5/2);
		wallWest.transform.localScale = new Vector3 (1f, 5f, 1f + size*5);

		GameObject wallEast = GameObject.Find ("Wall East");
		wallEast.transform.position = new Vector3 ((float)size*5, 2.5f, (float)size*5/2);
		wallEast.transform.localScale = new Vector3 (1f, 5f, 1f + size*5);

		// Return player to center
		GameObject player = GameObject.Find (Constants.playerName);
		player.transform.position = new Vector3 ((float)size*5/2, 1f, (float)size*5/2);

		// Set up maze walls
		for (int row = 0; row < maze.GetLength(0); row++)
		{
			for (int col = 0; col < maze.GetLength(1); col++)
			{
				MazeCell cell = maze[row,col];
				if (!cell.topOpen) {
					GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
					cube.transform.position = new Vector3(2.5f+5*col, 2.5f, (float)size*5-5*row);
					cube.transform.localScale = new Vector3(6f, 5f, 1f);
					cube.transform.parent = mazeWalls.transform;
				}
				if (!cell.leftOpen) {
					GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
					cube.transform.position = new Vector3(0f + 5*col, 2.5f, (float)size*5-2.5f-5*row);
					cube.transform.localScale = new Vector3(1f, 5f, 6f);
					cube.transform.parent = mazeWalls.transform;
				}
			}    
		}

		// Place portal in random position on edge
		int portalRow = Random.Range (0, 3);
		int portalCol = Random.Range (0, 3);
		while (portalRow == 1 && portalCol == 1) {
			portalRow = Random.Range (0, 3);
			portalCol = Random.Range (0, 3);
		}

		float portalX = 2.5f + (size/2)*5*portalCol;
		float portalY = 2.5f + (size/2)*5*portalRow;
		if (size % 2 == 0) {
			if (portalCol == 2) {
				portalX -= 5f;
			}
			if (portalRow == 2) {
				portalY -= 5f;
			}
		}
		portal = (GameObject)GameObject.Instantiate 
				(portalPrefab, new Vector3 (portalX, 0.05f, portalY), Quaternion.identity);
		portal.name = Constants.portalName;

		// Place key in random position not on portal
		int keyRow = Random.Range (0, 3);
		int keyCol = Random.Range (0, 3);
		while ((keyRow == 1 && keyCol == 1) || (keyRow == portalRow && keyCol == portalCol)) {
			keyRow = Random.Range (0, 3);
			keyCol = Random.Range (0, 3);
		}

		float keyX = 2.5f + (size/2)*5*keyCol;
		float keyY = 2.5f + (size/2)*5*keyRow;
		if (size % 2 == 0) {
			if (keyCol == 2) {
				keyX -= 5f;
			}
			if (keyRow == 2) {
				keyY -= 5f;
			}
		}
		GameObject portalKey = (GameObject)GameObject.Instantiate
				(portalKeyPrefab, new Vector3(keyX, 1.5f, keyY), Quaternion.Euler (35.3f, 0f, 45f));
		portalKey.name = Constants.portalKeyName;

	}

	public static void resetMaze(int size) {
		foreach(Transform child in mazeWalls.transform) {
			GameObject.Destroy (child.gameObject);
		}
		GameObject.Destroy (GameObject.Find (Constants.portalName));
		GameObject.Destroy (GameObject.Find (Constants.portalKeyName));
		drawMaze (size);
	}

	private static MazeCell[,] generate(int size) {
		
		MazeCell[,] maze = new MazeCell[size,size];
		
		maze[0,0] = new MazeCell(0, 0, true, true, int.MaxValue, int.MaxValue);
		
		// Randomize weights in first row.
		for (int i=1; i<size; i++) {
			int leftWeight = Random.Range(0, RAND_RANGE);
			maze[0,i] = new MazeCell(0, i, true, false, int.MaxValue, leftWeight);
		}
		
		// Randomize weights in first col.
		for (int i=1; i<size; i++) {
			int topWeight = Random.Range(0, RAND_RANGE);
			maze[i,0] = new MazeCell(i, 0, false, true, topWeight, int.MaxValue);
		}
		
		// Randomize weights of others.
		for (int i=1; i<size; i++) {
			for (int j=1; j<size; j++) {
				int leftWeight = Random.Range(0, RAND_RANGE);
				int topWeight = Random.Range(0, RAND_RANGE);
				maze[i,j] = new MazeCell(i, j, false, false, topWeight, leftWeight);
			}
		}

		EdgeWeightPriorityQueue q = new EdgeWeightPriorityQueue ();

		bool[,] reachedCells = new bool[size,size];
		
		MazeCell end = maze[size-1,size-1];
		reachedCells[size-1,size-1] = true;
		q.Enqueue(new EdgeWeight(end, false, end.leftWeight));
		q.Enqueue(new EdgeWeight(end, true, end.topWeight));
		
		int resolved = 1;

		// Keep looping until all cells are resolved.
		while (resolved < size*size) {
			EdgeWeight e = q.Dequeue();
			MazeCell cell = e.cell;
			if (e.isTop && cell.row-1 >= 0) {
				if (!reachedCells[cell.row-1,cell.col]) {
					MazeCell added = maze[cell.row-1,cell.col];
					reachedCells[cell.row-1,cell.col] = true;
					cell.setTopOpen(true);
					resolved++;
					
					q.Enqueue(new EdgeWeight(added, false, added.leftWeight));
					q.Enqueue(new EdgeWeight(added, true, added.topWeight));
					if (added.col < size-1) {
						MazeCell adj = maze[added.row,added.col+1];
						q.Enqueue(new EdgeWeight(adj, false, adj.leftWeight));
					}
				} else if (!reachedCells[cell.row,cell.col]) {
					// This IS the added cell
					reachedCells[cell.row,cell.col] = true;
					cell.setTopOpen(true);
					resolved++;
					
					q.Enqueue(new EdgeWeight(cell, false, cell.leftWeight));
				}
				
			} else if (cell.col-1 >= 0) {
				if (!reachedCells[cell.row,cell.col-1]) {
					MazeCell added = maze[cell.row,cell.col-1];
					reachedCells[cell.row,cell.col-1] = true;
					cell.setLeftOpen(true);
					resolved++;
					
					q.Enqueue(new EdgeWeight(added, false, added.leftWeight));
					q.Enqueue(new EdgeWeight(added, true, added.topWeight));
					if (added.row < size-1) {
						MazeCell adj = maze[added.row+1,added.col];
						q.Enqueue(new EdgeWeight(adj, true, adj.topWeight));
					}
				} else if (!reachedCells[cell.row,cell.col]) {
					// This IS the added cell
					reachedCells[cell.row,cell.col] = true;
					cell.setLeftOpen(true);
					resolved++;
					
					q.Enqueue(new EdgeWeight(cell, true, cell.topWeight));
				}
			}			
		}
		
		return maze;
	}
}
