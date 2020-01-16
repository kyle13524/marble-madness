//File Name: SwingingHammer.cs
//Description: This component controls rotation and speed of the swinging hammers.
//Programmer: Kyle Jensen
//Date: October 6, 2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingHammer : MonoBehaviour 
{
	[SerializeField]
	private Transform hinge;
	[SerializeField]
	private float swingSpeed = 20.0f;

	[SerializeField]
	private Vector3 startRotation = Vector3.zero;
	[SerializeField]
	private Vector3 endRotation = Vector3.zero;

	private Vector3 swingDirection = Vector3.zero;
	private Vector3 destinationRotation = Vector3.zero;

	// Use this for initialization
	void Start () 
	{
		transform.localRotation = Quaternion.Euler(startRotation);
		destinationRotation = endRotation;
		swingDirection = transform.forward;
	}

	/// <summary>
	/// Check the distance of the local rotation of the object against the destination angle, and switch
	/// if we have reached the destination angle. 
	/// </summary>
	void FixedUpdate () 
	{
		if (Vector3.Distance (transform.localRotation.eulerAngles, destinationRotation) < swingSpeed * Time.fixedDeltaTime) 
		{
			//Set destination to opposite side and flip swing direction
			destinationRotation = (destinationRotation == startRotation) ? endRotation : startRotation;
			swingDirection = -swingDirection;
		}

		//Rotate around the hinge and swing in the specified direction and speed.
		transform.RotateAround (hinge.position, swingDirection, swingSpeed * Time.fixedDeltaTime);
	}
}
