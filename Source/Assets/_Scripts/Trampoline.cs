//File Name: Trampoline.cs
//Description: This component shoots the player upwards by a specified velocity when they come
//				in contact with the collider.
//Programmer: Kyle Jensen
//Date: October 6, 2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour 
{
	public float bounceHeight = 100f;

	/// <summary>
	/// This collision happens when a player collides with a trampoline. It bounces them upwards.
	/// </summary>
	/// <param name="col">Col.</param>
	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag ("Player")) 
		{
			//Add bounce force
			col.rigidbody.AddForce (0, bounceHeight, 0);

			//Play bounce clip
			AudioSource source = SoundManager.Instance.GameAudioSource;
			source.PlayOneShot (SoundManager.Instance.BounceClip);
		}			
	}
}
