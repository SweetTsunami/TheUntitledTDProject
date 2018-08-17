/*  File:       #SCRIPTNAME#
 *  Creator:    Sweet
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
 
 using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the options menu
/// </summary>
public class OptionsController : MonoBehaviour
{
    /// <summary>
    /// volumeSlider            - sets the master volume
    /// difficultySlider        - sets the difficulty
    /// levelManager            - moving between sceenes
    /// </summary>
	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;

    // persistant music player
	private MusicManager musicManager;
    
    /// <summary>
    /// finds music manager
    /// gets the volume and difficulty values
    /// </summary>
	void Start ()
    {
		musicManager = FindObjectOfType<MusicManager>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}

    /// <summary>
    /// changes the volume
    /// </summary>
	void Update ()
    {
		musicManager.ChangeVolume(volumeSlider.value);
	}

    /// <summary>
    /// saves the options and exits the scene
    /// </summary>
	public void SaveAndExit()
	{		
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(difficultySlider.value);
		Debug.Log("Difficulty set to after exiting options : " + PlayerPrefsManager.GetDifficulty());
		Debug.Log("Volume set to after exiting options : " + PlayerPrefsManager.GetMasterVolume());
		levelManager.LoadLevel("01a_StartMenu");
	}

    /// <summary>
    /// sets the default values of sliders
    /// </summary>
	public void SetDefaults()
	{
		volumeSlider.value = 0.75f;
		difficultySlider.value = 2f;
	}
}
