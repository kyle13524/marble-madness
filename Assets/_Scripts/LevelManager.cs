//File Name: LevelManager.cs
//Description: This component controls the current level
//Programmer: Kyle Jensen
//Date: October 6, 2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour 
{
	public const int MaxLevel = 2;
	public static Level CurrentLevel;

	/// <summary>
	/// This method ends the game based on a status parameter. It displays the result panel.
	/// </summary>
	/// <param name="statusText">Status text.</param>
	public static void EndGame(string statusText)
	{
		Time.timeScale = 0f;
		HUDManager.GamePlayPanel.SetActive (false);
		HUDManager.GameResultPanel.SetActive (true);
		HUDManager.GameResultLabelText.text = statusText;
		HUDManager.GameResultTimeText.text = "Time: " + HUDManager.TimerText.text;
		HUDManager.GameResultLevelText.text = "Level: " + CurrentLevel.LevelNumber;
	}

	/// <summary>
	/// This method switches the current level and updates the text
	/// </summary>
	/// <param name="level">Level.</param>
	public static void SwitchLevels(Level level)
	{
		HUDManager.LevelText.text = "Level: " + level.LevelNumber;
		CurrentLevel = level;
	}
}
