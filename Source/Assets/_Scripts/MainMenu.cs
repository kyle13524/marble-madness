//File Name: MainMenu.cs
//Description: This component is used to start the game and set the music and environment sounds.
//Programmer: Kyle Jensen
//Date: October 6, 2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	/// <summary>
	/// This method loads the game scene and the music
	/// </summary>
	public void PlayGame()
	{
		SceneManager.LoadScene ("Game");
		SoundManager.Instance.EnvironmentAudioSource.Play ();
		SoundManager.Instance.MusicAudioSource.clip = SoundManager.Instance.GameMusic;
		SoundManager.Instance.MusicAudioSource.Play ();
	}

}
