/*  File:       #SCRIPTNAME#
 *  Creator:    Sweet
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
 
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the constants that are supposed to be saved between sessions
/// </summary>
public class PlayerPrefsManager : MonoBehaviour
{
	#region Constants
	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	#endregion
	#region Setters
	public static void SetMasterVolume(float volume)
	{
		if (volume >= 0f && volume <= 1f)
		{
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		}
		else
		{
			Debug.LogError("Master volume out of range");
		}
	}
	public static void SetDifficulty(float difficulty)
	{
		if (difficulty >= 1 && difficulty <= 3)
		{
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		}
		else
		{
			Debug.LogError("Difficulty out of range");
		}
	}
	#endregion
	#region Getters
	public static float GetMasterVolume()
	{
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	public static float GetDifficulty()
	{
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
	#endregion
	#region Others
	public static void UnlockLevel(int level)
	{
		if (level <= SceneManager.sceneCount - 1)
		{
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); //use 1 for true, coz no bools in player prefs
		}
		else
		{
			Debug.LogError("Trying to unlock level not in build order");
		}
	}
	public static bool IsLevelUnlocked(int level)
	{
		int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);

		if (level <= SceneManager.sceneCount - 1)
		{
			return isLevelUnlocked;
		}
		else
		{
			Debug.LogError("Trying to unlock level not in build order");
			return false;
		}
	}
	#endregion
}
