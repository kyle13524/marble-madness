using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour 
{
	float scrollSpeed_X = 0.5f;
	float scrollSpeed_Y = 0.5f;

	private new Renderer renderer;

	// Use this for initialization
	void Start () 
	{
		this.renderer = this.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float offsetX = Time.time * scrollSpeed_X;
		float offsetY = Time.time * scrollSpeed_Y;
		renderer.material.mainTextureOffset = new Vector2 (offsetX, offsetY);
	}
}
