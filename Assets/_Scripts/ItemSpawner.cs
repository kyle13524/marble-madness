//File Name: ItemSpawner.cs
//Description: This component spawns an item prefab at its parent at a specific spawn speed.
//Programmer: Kyle Jensen
//Date: October 6, 2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour 
{
	[SerializeField]
	private float spawnSpeed = 10f;

	[SerializeField]
	private GameObject itemPrefab;

	[SerializeField]
	private Transform parent;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine ("SpawnItem");
	}
		
	/// <summary>
	/// This coroutine instantiates an item at its parent, and waits a specific
	/// amount of time to do it again.
	/// </summary>
	/// <returns>The item.</returns>
	private IEnumerator SpawnItem()
	{
		while (true) 
		{
			Instantiate (itemPrefab, parent);
			yield return new WaitForSeconds (spawnSpeed);
		}
	}
}
