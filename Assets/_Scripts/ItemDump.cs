//File Name: ItemDump.cs
//Description: This component destroys objects that go within its collider. Used for destroying logs.
//Programmer: Kyle Jensen
//Date: October 6, 2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ItemDump : MonoBehaviour 
{
	/// <summary>
	/// If the object entering this is not the player, we destroy.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter(Collider col)
	{
		if (!col.gameObject.CompareTag ("Player")) 
		{
			Destroy (col.gameObject);
		}
	}
}
