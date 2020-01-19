//File Name: LogDropper.cs
//Description: This component causes an object to use gravity on a trigger. Used when log drops off clif.
//Programmer: Kyle Jensen
//Date: October 6, 2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogDropper : MonoBehaviour 
{
	/// <summary>
	/// This trigger occurs when a log hits the trigger and sets it to use gravity instead
	/// of being kintematic. It also disables the logs movement path.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag ("Log")) 
		{
			Rigidbody rb = col.GetComponent<Rigidbody> ();
			rb.isKinematic = false;
			rb.useGravity = true;

			col.GetComponent<MovementPath> ().enabled = false;
		}
	}
}
