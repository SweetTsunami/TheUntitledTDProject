/*  File:       #SCRIPTNAME#
 *  Creator:    Sweet
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
 
 using UnityEngine;

/// <summary>
/// Sets the volume of music manager
/// </summary>
public class SetVolume : MonoBehaviour
{
    private MusicManager musicManager;
    
    /// <summary>
    /// finds the music manager
    /// if there is a music manager, set it's volume with value from PlayerPrefsManager
    /// </summary>
	void Start ()
    {
		musicManager = FindObjectOfType<MusicManager>();
		if (musicManager)
		{
			float volume = PlayerPrefsManager.GetMasterVolume();
			musicManager.ChangeVolume(volume);
			Debug.Log("Found music manager " + musicManager);
		}
		else
		{
			Debug.LogError("No music manager found!!!");
		}		
	}
}
