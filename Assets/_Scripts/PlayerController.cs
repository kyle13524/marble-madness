//File Name: PlayerController.cs
//Description: This component controls the players movement in the game.
//Programmer: Kyle Jensen
//Date: October 6, 2017

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class PlayerController : MonoBehaviour 
{
	private const float kSpeed = 600f;

	private new Rigidbody rigidbody;
	private float maxVelocity = 8f;

	private bool isGrounded = true;

	private Transform cameraTransform;

	void Start () 
	{
		rigidbody = GetComponent<Rigidbody> ();
		cameraTransform = Camera.main.transform;
	}


	/// <summary>
	/// We want to move the character if they are not applying brakes and if they are grounded.
	/// </summary>
	void FixedUpdate () 
	{
		if (!Input.GetKey (KeyCode.Space)) 
		{
			float inputX = Input.GetAxis ("Horizontal");
			float inputZ = Input.GetAxis ("Vertical");
			Vector3 movementVector = new Vector3 (inputX, 0, inputZ);
			Vector3 force = Vector3.zero;

			//Set the movement speed to 1/2 of the speed when in the air
			float movementSpeed = (!isGrounded) ? kSpeed / 2 : kSpeed;

			//Transform the movement direction to be relative to the camera position
			movementVector = cameraTransform.TransformDirection (movementVector);
			movementVector.y = 0.0f;

			//Set the force to the movement direction we wish to move
			force = movementVector * movementSpeed * Time.fixedDeltaTime;	

			//Add movement force
			rigidbody.AddForce (force);
		} 
		else if(isGrounded)
		{
			rigidbody.velocity *= 0.9f;
			rigidbody.angularVelocity *= 0.9f;
		}

		//If our current velocity is greater than the max velocity, add an opposing force to the object
		float currentVelocity = Vector3.Magnitude (rigidbody.velocity);
		if(currentVelocity > maxVelocity)
		{
			//Get the speed in the opposite direction
			float opposingSpeed = currentVelocity - maxVelocity;
			Vector3 opposingForce = Vector3.Normalize (rigidbody.velocity) * opposingSpeed;

			//Add an opposing force to the object
			rigidbody.AddForce (-opposingForce);
		}

		//Play rolling sound when moving
		PlayRollingSound ();
	}

	/// <summary>
	/// This method checks if the player is moving by checking the velocity and plays the roll sound
	/// </summary>
	public void PlayRollingSound()
	{
		AudioSource source = SoundManager.Instance.PlayerAudioSource;

		//If we arent grounded but the sound is playing, stop it.
		if (!isGrounded && source.isPlaying) 
		{
			source.Stop ();
			return;
		}

		//If we are moving, play sound if not playing
		if (rigidbody.velocity.magnitude > 0.4f) 
		{
			if (!source.isPlaying) 
			{
				source.Play ();
			}
		} 
		else if(source.isPlaying)
		{
			source.Stop ();
		}
	}

	/// <summary>
	/// This method overrides the position of the player
	/// </summary>
	/// <param name="position">Position.</param>
	public void SetPosition(Vector3 position)
	{
		rigidbody.MovePosition (position);
	}

	/// <summary>
	/// This method overrides the velocity of the player
	/// </summary>
	/// <param name="vel">Vel.</param>
	public void SetVelocity(Vector3 vel)
	{
		rigidbody.velocity = vel;
	}

	#region Collision Detection

	/// <summary>
	/// Check if the player is colliding with a platform, if so they are grounded
	/// </summary>
	/// <param name="col">Col.</param>
	private void OnCollisionEnter(Collision col)
	{
		if (!isGrounded && col.gameObject.CompareTag ("Platform"))
		{
			isGrounded = true;
		}
	}

	/// <summary>
	/// Check if the player is colliding with a platform, if so they are grounded
	/// </summary>
	/// <param name="col">Col.</param>
	private void OnCollisionStay(Collision col)
	{
		if (!isGrounded && col.gameObject.CompareTag ("Platform"))
		{
			isGrounded = true;
		}
	}

	/// <summary>
	/// Check if the player has stopped colliding with a platform, set is grounded to false
	/// </summary>
	/// <param name="col">Col.</param>
	private void OnCollisionExit(Collision col)
	{
		if (isGrounded && col.gameObject.CompareTag ("Platform")) 
		{
			isGrounded = false;
		}
	}
	#endregion
		
}
