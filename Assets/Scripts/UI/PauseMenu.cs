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
/// Handles the pause menu UI
/// </summary>
public class PauseMenu : MonoBehaviour 
{
    public GameObject PauseUI;
    
    /// <summary>
    /// If player pressed Esc or P TogglePauseMenu();
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu();
        }
    }

    /// <summary>
    /// Switches the UI on and off, if the UI is on, stop the time.
    /// </summary>
    public void TogglePauseMenu()
    {
        PauseUI.SetActive(!PauseUI.activeSelf);

        if (PauseUI.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    /// <summary>
    /// Reload current scene
    /// </summary>
    public void Retry()
    {
        TogglePauseMenu();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Go to menu (World map)
    /// </summary>
    public void Menu()
    {
        SceneManager.LoadScene("02_WorldMap");
        Time.timeScale = 1;
    }
}
