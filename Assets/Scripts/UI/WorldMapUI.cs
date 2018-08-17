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
/// Handles the behavior of World Map UI
/// </summary>
public class WorldMapUI : MonoBehaviour 
{
    // UI object variables to set active/inactive
    public GameObject techTreeUI;
    public GameObject logUI;
    public GameObject envirovment;

    // Text fields
    public Text techPointAmmountText;
    public Text globalMoneyAmmountText;
    public Text attackPointsAmmountText;
    public Text turnCounterText;

    // turn counter
    private static int turnCounter = 1;

    /// <summary>
    /// Initializes the values of text fields
    /// </summary>
    void OnEnable()
    {
        turnCounterText.text = "TURN:" + turnCounter.ToString();
        techPointAmmountText.text = "Tech: " + Inventory.techPoints;
        globalMoneyAmmountText.text = "Cash: " + Inventory.globalMoney;
        attackPointsAmmountText.text = Inventory.attackPoints + "/" + Inventory.attackPointsLimit;
    }    

    /// <summary>
    /// Handles the next turn button
    /// </summary>
    public void NextTurn()
    {
        // increment turn counter
        turnCounter++;
        turnCounterText.text = "TURN:"+ turnCounter.ToString();
        
        // TODO : next turn logic
        // refresh of the attack points
        Inventory.attackPoints = Inventory.attackPointsLimit;
        attackPointsAmmountText.text = Inventory.attackPoints + "/" + Inventory.attackPointsLimit;
    }
}
