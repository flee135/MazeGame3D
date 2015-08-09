using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EdgeWeightPriorityQueue {
	Queue<EdgeWeight> aQueue;
	private SortedDictionary<int, Queue<EdgeWeight>> theDic;

	public EdgeWeightPriorityQueue() {
		theDic = new SortedDictionary<int, Queue<EdgeWeight>>();
	}

	public void Enqueue(EdgeWeight toEnqueue)
	{

		//no key exists for this value we must create a key and queue
		if (!theDic.TryGetValue(toEnqueue.weight, out aQueue))
		{	//came back null create a new Queue for this slot	
			aQueue = new Queue<EdgeWeight>();
			aQueue.Enqueue(toEnqueue);
			theDic.Add(toEnqueue.weight, aQueue);
		}
		//queue already exists inside the dictionary append to exisiting key
		else { aQueue.Enqueue(toEnqueue); }
	}

	/// <summary>
	/// Dequeues the lowest costing node and returns it.
	/// </summary>
	/// <returns></returns>
	public EdgeWeight Dequeue()
	{
		var pair = theDic.First();
		EdgeWeight toReturn = pair.Value.Dequeue();
		//check if nothing is left if so destroy this key
		if (pair.Value.Count == 0) { theDic.Remove(pair.Key); }
		return toReturn;
	}

	/// <summary>
	/// How many Node values are Enqueue
	/// </summary>
	public int Count { get { return theDic.Count; } private set { } }

	/// <summary>
	/// Does the queue contain this node?
	/// </summary>
	/// <param name="toCheck"></param>
	/// <returns></returns>
	public bool Contains(EdgeWeight toCheck)
	{
		//See if there is a key containing this value
		if (!theDic.TryGetValue(toCheck.weight, out aQueue)) { return false; }
		//Key exists does its queue contain this node
		if (aQueue.Contains(toCheck)) { return true; }
		return false;
	}
}
