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
/// Handles the player lives UI
/// </summary>
public class PlayerHealthUI : MonoBehaviour
{
    public Text playerHealthText;

	void Update ()
    {
        playerHealthText.text = ""+ GameMaster.PlayerHealth.ToString();
	}
}
