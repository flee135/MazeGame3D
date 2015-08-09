using UnityEngine;
using System;
using System.Collections;

public class EdgeWeight :  IComparable<EdgeWeight> {

	public MazeCell cell;
	public bool isTop;
	public int weight;
	
	public EdgeWeight(MazeCell cell, bool isTop, int weight) {
		this.cell = cell;
		this.isTop = isTop;
		this.weight = weight;
	}

	public int CompareTo(EdgeWeight that)
	{
		return this.weight - that.weight;
	}
}
