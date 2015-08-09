using UnityEngine;
using System.Collections;

public class MazeCell {

	public int row;
	public int col;
	public bool topOpen;
	public bool leftOpen;
	public int topWeight;
	public int leftWeight;
	
	public MazeCell(int row, int col, bool topOpen, bool leftOpen, int topWeight, int leftWeight) {
		this.row = row;
		this.col = col;
		this.topOpen = topOpen;
		this.leftOpen = leftOpen;
		this.topWeight = topWeight;
		this.leftWeight = leftWeight;
	}
	
	public void setTopOpen(bool b) {
		topOpen = b;
	}
	
	public void setLeftOpen(bool b) {
		leftOpen = b;
	}
	
	public void setTopWeight(int n) {
		topWeight = n;
	}
	
	public void setLeftWeight(int n) {
		leftWeight = n;
	}
}
