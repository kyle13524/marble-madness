//File Name: Coin.cs
//Description: This component holds the trigger for a coin. When we collect a coin we want to notify
//				the level, play a coin bloop, and destroy the coin.
//Programmer: Kyle Jensen
//Date: October 6, 2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{
	/// <summary>
	/// This method checks if a trigger has occured with the player, and notifies the level
	/// and plays a coin bloop before destroying itself.
	/// </summary>
	/// <param name="coll">Coll.</param>
	void OnTriggerEnter(Collider coll)
	{
		if (coll.transform.tag == "Player") 
		{
			LevelManager.CurrentLevel.CurrentCheckpoint.CollectCoin();
			AudioSource source = SoundManager.Instance.GameAudioSource;
			source.PlayOneShot(SoundManager.Instance.CoinClip);
			Destroy (this.gameObject);
		}
	}
}
