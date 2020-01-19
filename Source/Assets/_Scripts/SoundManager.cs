//File Name: SoundManager.cs
//Description: This component manages the audio sources and clips within the game. 
//Programmer: Kyle Jensen
//Date: October 6, 2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour 
{
	public AudioSource EnvironmentAudioSource;
	public AudioSource MusicAudioSource;
	public AudioSource GameAudioSource;
	public AudioSource PlayerAudioSource;

	public AudioClip CoinClip;
	public AudioClip BounceClip;
	public AudioClip WhooshClip;
	public AudioClip RollClip;

	public AudioClip MenuMusic;
	public AudioClip GameMusic;

	//Static instance for singleton pattern.
	public static SoundManager Instance;

	void Start()
	{
		DontDestroyOnLoad (this);
	}

	/// <summary>
	/// Private constructor for singleton pattern.
	/// </summary>
	private SoundManager()
	{
		Instance = this;
	}

	/// <summary>
	/// This method changes the volume of the environment audio source
	/// </summary>
	/// <param name="vol">Vol.</param>
	public void ChangeEnvironmentVolume(float vol)
	{
		EnvironmentAudioSource.volume = vol;
	}
		
	/// <summary>
	/// This method changes the volume of the music audio source
	/// </summary>
	/// <param name="vol">Vol.</param>
	public void ChangeMusicVolume(float vol)
	{
		MusicAudioSource.volume = vol;
	}

	/// <summary>
	/// This method changes the volume of the game sounds audio source
	/// </summary>
	/// <param name="vol">Vol.</param>
	public void ChangeGameVolume(float vol)
	{
		GameAudioSource.volume = vol;
	}
}
