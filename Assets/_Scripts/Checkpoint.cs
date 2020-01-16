//File Name: Checkpoint.cs
//Description: This component creates a checkpoint and assigns coins to the checkpoint.
//Programmer: Kyle Jensen
//Date: October 6, 2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour 
{
	private TextMesh checkpointTextMesh;
	[SerializeField]
	private List<Transform> coinSpawns;
	[SerializeField]
	private GameObject coinPrefab;

	private int coinsCollected;

	public Transform SpawnPoint;
	public Transform EndPoint;

	public bool Active { get; private set; }
	public bool Completed { get; set; }

	void Start()
	{
		checkpointTextMesh = GetComponentInChildren<TextMesh> ();
	}

	/// <summary>
	/// This method activates the checkpoint and spawns coins. Called on the next checkpoint
	/// when a checkpoint is complete.
	/// </summary>
	public void Activate()
	{
		this.Active = true;
		this.SpawnCoins ();

		//Set the text mesh if it exists
		if (checkpointTextMesh != null)
			checkpointTextMesh.transform.GetComponent<MeshRenderer> ().enabled = true;
	}

	/// <summary>
	/// This method spawns coins at the positions on the checkpoint.
	/// </summary>
	void SpawnCoins()
	{
		foreach (Transform t in coinSpawns) 
		{
			Debug.Log ("Coin");
			GameObject go = Instantiate (coinPrefab, t.position, t.rotation);
			go.transform.parent = t;
		}

		coinsCollected = 0;
		UpdateLabelText ();
	}

	/// <summary>
	/// This method collects a coin and checks if all the coins have been collected.
	/// </summary>
	public void CollectCoin()
	{
		coinsCollected++;
		if (coinsCollected == coinSpawns.Count) 
		{
			Completed = true;

		}
		UpdateLabelText ();
	}

	/// <summary>
	/// This method updates the 3D text label depending on what needs to be displayed.
	/// </summary>
	public void UpdateLabelText()
	{
		if (checkpointTextMesh != null) 
		{		
			if (LevelManager.CurrentLevel.Completed) 
			{
				checkpointTextMesh.text = "Level Complete";
			}
			else if (Completed) 
			{
				checkpointTextMesh.text = "Checkpoint";
			} 
			else 
			{
				checkpointTextMesh.text = coinsCollected + "/" + coinSpawns.Count + " Coins";
			}
		}
	}

	/// <summary>
	/// This event is called when a player collides with the checkpoint and activates the next checkpoint.
	/// </summary>
	/// <param name="coll">Coll.</param>
	private void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.CompareTag ("Player")) 
		{
			checkpointTextMesh.color = Color.cyan;

			LevelManager.CurrentLevel.NextCheckpoint ();
			UpdateLabelText ();
		}
	}

}
