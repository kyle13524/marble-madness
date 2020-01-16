//File Name: LevelPortal.cs
//Description: This component acts as a level portal to detect if the level is complete and to
//				allow the user to fall perfectly vertically down to the next level.
//Programmer: Kyle Jensen
//Date: October 6, 2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPortal : MonoBehaviour 
{
	[SerializeField]
	private Level level;
	[SerializeField]
	private GameObject levelBounds;


	/// <summary>
	/// This trigger occurs when the user colides with the final level portal.
	/// If they have not completed the level, they will respawn at the last checkpoint.
	/// If they have completed the level, they will be rewarded lives and get sucked down to the next level.
	/// </summary>
	/// <param name="coll">Coll.</param>
	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.CompareTag ("Player")) 
		{
			if (!level.Completed) 
			{
				level.Respawn ();
			} 
			else if (level.LevelNumber == LevelManager.MaxLevel) 
			{
				LevelManager.EndGame ("You Win!");
			}
			else
			{
				//Lock the player velocity so they are not moving while falling.
				LockPlayerVelocity (coll.gameObject);

				//Get the player and add lives
				Player player = coll.GetComponent<Player> ();
				player.Lives += 5;

				HUDManager.LivesText.text = "Lives: " + player.Lives;
				levelBounds.SetActive (false);
			}

			//Play the whoosh clip
			AudioSource source = SoundManager.Instance.GameAudioSource;
			source.PlayOneShot (SoundManager.Instance.WhooshClip);
		}
	}

	/// <summary>
	/// This method sets the players velocity to zero and disables the player controller.
	/// </summary>
	/// <param name="playerObject">Player object.</param>
	void LockPlayerVelocity(GameObject playerObject)
	{
		playerObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		playerObject.GetComponent<PlayerController> ().enabled = false;
	}
}
