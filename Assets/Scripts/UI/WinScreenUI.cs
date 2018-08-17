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
/// Handles the win screen UI
/// </summary>
public class WinScreenUI : MonoBehaviour 
{
    public void BackToWorldMap()
    {
        SceneManager.LoadScene("02_WorldMap");
    }
}
