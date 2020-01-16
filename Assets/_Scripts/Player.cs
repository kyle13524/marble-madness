//File Name: Player.cs
//Description: This component holds information about the player.
//Programmer: Kyle Jensen
//Date: October 6, 2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour 
{
	public int Lives { get; set; }
	public PlayerController Controller { get; private set; }


	/// <summary>
	/// Set up lives and reference to player controller.
	/// </summary>
	void Awake () 
	{
		this.Lives = 5;	
		this.Controller = this.GetComponent<PlayerController> ();
	}

	/// <summary>
	/// Respawn when entering restricted areas
	/// </summary>
	/// <param name="coll">Coll.</param>
	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.CompareTag ("Restricted")) 
		{
			LevelManager.CurrentLevel.Respawn ();
		}
	}

}
