//File Name: MovingPlatform.cs
//Description: This component moves a platform between two positions and pauses between.
//Programmer: Kyle Jensen
//Date: October 6, 2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingPlatform : MonoBehaviour 
{	
	private new Rigidbody rigidbody;

	[SerializeField]
	private Transform startTransform;

	[SerializeField]
	private Transform endTransform;

	[SerializeField]
	private float speed;

	private Vector3 direction;
	private Transform currentDestination;

	[SerializeField]
	private float pauseTime;
	private float elapsedTimeOnDestination;

	void Start()
	{
		rigidbody = this.GetComponent<Rigidbody> ();
		SetDestination (startTransform);
	}

	/// <summary>
	/// This method moves us towards our destination and checks if we have reached our destination.
	/// If we have reached our destination we set the timer to the pause time and set the new destination
	/// after the time has expired.
	/// </summary>
	void FixedUpdate()
	{
		if (Vector3.Distance (transform.position, currentDestination.position) < speed * Time.fixedDeltaTime) 
		{
			if (elapsedTimeOnDestination > pauseTime) 
			{
				SetDestination (currentDestination == startTransform ? endTransform : startTransform);
				elapsedTimeOnDestination = 0f;
			}
			elapsedTimeOnDestination += Time.fixedDeltaTime;
		}
		else 
		{
			rigidbody.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
		}
	}

	/// <summary>
	/// This method sets the destination to the new destination and sets the direction
	/// </summary>
	/// <param name="destination">Destination.</param>
	void SetDestination(Transform destination)
	{
		currentDestination = destination;
		direction = (currentDestination.position - transform.position).normalized;
	}
}
