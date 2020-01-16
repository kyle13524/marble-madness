//File Name: MovementPath.cs
//Description: This component creates a path of transforms for the object to follow. 
//Programmer: Kyle Jensen
//Date: October 6, 2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementPath : MonoBehaviour 
{
	[SerializeField]
	private float speed = 3.0f;

	[SerializeField]
	private float rotateSpeed = 2.0f;

	[SerializeField]
	private bool isLooping = false;

	[SerializeField]
	private List<Transform> pathPositions = new List<Transform>();

	private Vector3 direction;
	private Transform destination;
	private int currentIndex = 0;

	private bool finished = false;

	private new Rigidbody rigidbody;

	void Start () 
	{
		rigidbody = this.GetComponent<Rigidbody> ();
		destination = pathPositions [currentIndex];
		direction = (destination.position - transform.position).normalized;
	}

	/// <summary>
	/// This method moves the object towards its current path destination and checks
	/// if we have reached the destination to switch to the next. If
	/// </summary>
	void FixedUpdate () 
	{
		//If we arent finished and we have positions to go to
		if (pathPositions.Count > 0 && !finished) 
		{
			//Check if we are at our destination.
			if (Vector3.Distance (transform.position, destination.position) < speed * Time.fixedDeltaTime) 
			{
				//Get next destination and set direction
				GetNextDestination();
				direction = (destination.position - transform.position).normalized;
			}

			//Set rotation to lerp to the face the destination rotation
			transform.rotation = Quaternion.Lerp(transform.rotation, destination.rotation, rotateSpeed * Time.fixedDeltaTime);

			//Move object in direction
			rigidbody.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
		}
	}
		
	/// <summary>
	/// This method gets the next destination in the path. If its looping it will
	/// restart from the first index.
	/// </summary>
	void GetNextDestination()
	{
		if (currentIndex < pathPositions.Count)	
		{
			currentIndex++;
		}
		else
		{
			if (isLooping) 
			{
				currentIndex = 0;
			}
			else
			{
				finished = true;
			}
		}
		destination = pathPositions [currentIndex];
	}
}
