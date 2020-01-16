//File Name: Level.cs
//Description: This component controls the flow of a level, and manages its checkpoints.
//Programmer: Kyle Jensen
//Date: October 6, 2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour 
{
	[SerializeField]
	private List<Checkpoint> checkpoints;
	private int checkpointIndex = 0;

	public Checkpoint CurrentCheckpoint { get; private set; }

	private Player player;

	public bool Started { get; set; }
	public bool Completed { get; set; }
	public int LevelNumber;

	// Use this for initialization
	void Start () 
	{		
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		HUDManager.LivesText.text = "Lives: " + player.Lives;
	}

	/// <summary>
	/// This method respawns the player at the current checkpoint and sets their velocity to zero.
	/// It also reduces their lives or calls the game over method
	/// </summary>
	public void Respawn()
	{
		player.Controller.SetVelocity (Vector3.zero);	
		player.Controller.SetPosition (CurrentCheckpoint.SpawnPoint.position);

		//If we have a life, remove one c:
		if (player.Lives > 0) 
		{
			player.Lives -= 1;
			HUDManager.LivesText.text = "Lives: " + player.Lives;
		} 
		else 
		{
			//Game Over
			LevelManager.EndGame ("Game Over");
		}
	}
		
	/// <summary>
	/// This method steps the current checkpoint to the next checkpoint to be activated.
	/// If there are no more checkpoints, the level is considered complete.
	/// </summary>
	public void NextCheckpoint()
	{
		if (checkpointIndex + 1 < checkpoints.Count) 
		{
			var old = CurrentCheckpoint;
			CurrentCheckpoint = checkpoints [checkpointIndex];
			checkpointIndex++;
		} 
		else 
		{
			Completed = true;
		}
	}

	/// <summary>
	/// This event happens when a collision occurs with the level platform. This is how a level
	/// is started. The user falls onto the level platform, and the level is loaded.
	/// </summary>
	/// <param name="coll">Coll.</param>
	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.CompareTag("Player"))
		{
			if (!Started) 
			{
				//Switch the current level to this one
				LevelManager.SwitchLevels (this);

				//Activate the first checkpoint
				CurrentCheckpoint = checkpoints [0];
				CurrentCheckpoint.Activate ();

				Started = true;
			}

			//Enable the player controller (could be disabled from falling to next level)
			player.Controller.enabled = true;
		}
	}
}
