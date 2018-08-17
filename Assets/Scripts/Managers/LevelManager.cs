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
/// Handles the level transfering
/// </summary>
public class LevelManager : MonoBehaviour
{
    //loads next level after x seconds
    public float autoLoadNextLevelAfter;

    /// <summary>
    /// setup of autoload on start
    /// </summary>
	void OnEnable()
    {
        if (autoLoadNextLevelAfter >= 0)
        {
            if (autoLoadNextLevelAfter != 0)
            {
                Invoke("LoadNextLevel", autoLoadNextLevelAfter);
            }
        }
        else
        {
            Debug.LogError("Negative autoLoadNextLevelAfter");
        }
    }

    /// <summary>
    /// loads level 
    /// </summary>
    /// <param name="name"></param>
	public void LoadLevel(string name)
    {
        Debug.Log("New Level load: " + name);
        SceneManager.LoadScene(name);
    }

    public void RestartLevel()
    {
        Debug.Log("Restarting level, New Level load: " + name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// quits the game
    /// </summary>
	public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    /// <summary>
    /// loads next level
    /// </summary>
	public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
