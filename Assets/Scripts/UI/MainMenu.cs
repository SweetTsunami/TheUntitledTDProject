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
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Enums for containing possible data
    /// </summary>
    public enum Difficulty { Easy, Medium, Hard};

    // Definition of Enums
    Difficulty selectedDifficulty;
    
    public void SelectDifficulty(int difficultyIndex)
    {
        selectedDifficulty = (Difficulty)difficultyIndex;
        Debug.Log("Selected difficulty = " + selectedDifficulty);
    }

    //done by level manager
    //public void QuitGame()
    //{
    //    Debug.Log("Quitting game");
    //    Application.Quit();
    //    Debug.Log("Game quit");
    //}
}
