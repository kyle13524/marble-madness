//File Name: CameraController.cs
//Description: This component controls the camera, allowing the user to revolve the camera around the player
//Programmer: Kyle Jensen
//Date: October 6, 2017

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	[SerializeField]
	private Transform target;
	[SerializeField]
	private float cameraSpeed = 5.0f;
	[SerializeField]
	private float cameraDistance = 12.0f;

	private float cameraX;
	private float cameraY = 30f;

	void Start () 
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	/// <summary>
	/// We change the values of the camera in late update so it occurs after player has moved.
	/// </summary>
	void LateUpdate () 
	{
		if (target == null) 
		{
			return;
		}

		//Change camera axis
		cameraX += Input.GetAxis ("CameraAxisX") * cameraSpeed;
		cameraY += Input.GetAxis ("CameraAxisY") * cameraSpeed;
		cameraY = Mathf.Clamp (cameraY, 0.0f, 60.0f);

		//Create new rotation
		Quaternion newRotation = Quaternion.Euler (cameraY, cameraX, 0);
		Vector3 offset = newRotation * Vector3.forward * cameraDistance;
		Vector3 newPosition = target.position - offset;

		//Assign rotation and position
		transform.position = newPosition;
		transform.rotation = newRotation;
	}
}
