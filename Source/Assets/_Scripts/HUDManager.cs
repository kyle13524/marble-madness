//File Name: HUDManager.cs
//Description: This class is used as a static reference to all the HUD elements that need
//				to be manipulated throughout the gameplay.
//Programmer: Kyle Jensen
//Date: October 6, 2017

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour 
{
	//Static references
	public static Text LevelText { get; private set; }
	public static Text LivesText { get; private set; }
	public static Text TimerText { get; private set; }
	public static GameObject GamePlayPanel { get; private set; }
	public static GameObject GameResultPanel { get; private set; }
	public static GameObject GamePausePanel { get; private set; }
	public static Text GameResultLabelText { get; private set; }
	public static Text GameResultTimeText { get; private set; }
	public static Text GameResultLevelText { get; private set; }
	public static Slider EnvironmentSoundSlider { get; private set; }
	public static Slider MusicSoundSlider { get; private set; }
	public static Slider GameSoundSlider { get; private set; }

	/// <summary>
	/// Initialize static references
	/// </summary>
	void Awake()
	{
		LevelText = GameObject.Find ("LevelText").GetComponent<Text> ();
		LivesText = GameObject.Find ("LivesText").GetComponent<Text> ();
		TimerText = GameObject.Find ("TimerText").GetComponent<Text> ();
		GamePlayPanel = GameObject.Find ("GamePlayPanel");
		GameResultPanel = GameObject.Find ("GameResultPanel");
		GamePausePanel = GameObject.Find ("PauseMenuPanel");
		GameResultTimeText = GameObject.Find ("GRTimeText").GetComponent<Text> ();
		GameResultLevelText = GameObject.Find ("GRLevelText").GetComponent<Text> ();
		GameResultLabelText = GameObject.Find ("GRLabel").GetComponent<Text> ();
		EnvironmentSoundSlider = GameObject.Find ("PMEnvironmentSlider").GetComponent<Slider> ();
		MusicSoundSlider = GameObject.Find ("PMMusicSlider").GetComponent<Slider> ();
		GameSoundSlider = GameObject.Find ("PMGameSlider").GetComponent<Slider> ();

		//Set panels to false
		GameResultPanel.SetActive (false);
		GamePausePanel.SetActive (false);

		//Get slider values that may have been changed on Main Menu
		InitializeSliderValues ();
	}


	/// <summary>
	/// This method initializes the value of the volume sliders to the volume level.
	/// </summary>
	void InitializeSliderValues()
	{
		EnvironmentSoundSlider.value = SoundManager.Instance.EnvironmentAudioSource.volume;
		MusicSoundSlider.value = SoundManager.Instance.MusicAudioSource.volume;
		GameSoundSlider.value = SoundManager.Instance.GameAudioSource.volume;
	}

	/// <summary>
	/// We check if escape has been hit, and if so call the pause method
	/// </summary>
	void Update()
	{
		if (Input.GetKey (KeyCode.Escape)) 
		{
			if (GameResultPanel.activeSelf == false) 
			{
				Pause ();
			}
		}
	}

	/// <summary>
	/// This method loads the game scene again
	/// </summary>
	public void PlayAgain()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Game");
	}

	/// <summary>
	/// This method loads the main menu scene and destroys the sound manager (re-built in main menu)
	/// </summary>
	public void MainMenu()
	{
		Time.timeScale = 1f;
		Destroy (SoundManager.Instance.gameObject);
		SceneManager.LoadScene ("MainMenu");
	}

	/// <summary>
	/// This method pauses the game by setting time scale to 0 and activating the pause panel
	/// </summary>
	public void Pause()
	{
		Time.timeScale = 0f;
		GamePausePanel.SetActive (true);
		GamePlayPanel.SetActive (false);
	}

	/// <summary>
	/// This method resumes the game by setting the time scale to 1 and activating the play panel
	/// </summary>
	public void Resume()
	{
		Time.timeScale = 1f;
		GamePausePanel.SetActive (false);
		GamePlayPanel.SetActive (true);
	}
}
