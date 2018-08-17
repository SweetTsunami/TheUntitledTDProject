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

/// <summary>
/// Handles the game over UI 
/// </summary>
public class GameOver : MonoBehaviour 
{
    public Text roundsText;

    void OnEnable()
    {
        roundsText.text = GameMaster.Round.ToString();
    }

    // done by level manager
    //public void Retry()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

    //public void Menu()
    //{
    //    SceneManager.LoadScene("02_WorldMap");
    //}
}

