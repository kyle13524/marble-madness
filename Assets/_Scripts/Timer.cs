//File Name: Timer.cs
//Description: This component runs a simple timer when they start the game, this time is displayed when they lose.
//Programmer: Kyle Jensen
//Date: October 6, 2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{
	public Text timerText;
	private float secondsCount;
	private int minuteCount;

	void Start()
	{
		timerText = this.GetComponent<Text> ();
	}

	/// <summary>
	/// This method counts up by delta time and adds minutes for every 60 seconds.
	/// </summary>
	void Update()
	{
		secondsCount += Time.deltaTime;
		timerText.text = minuteCount + "m:" +(int)secondsCount + "s";

		if(secondsCount >= 60)
		{
			minuteCount++;
			secondsCount = 0;
		}  
	}
}
