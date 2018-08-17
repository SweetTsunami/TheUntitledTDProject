/*  File:       UIManager
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

using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public GameObject selectedUI;

    public void DeselectUI()
    {
        selectedUI.SetActive(false);
        selectedUI = null;
    }

    public void ToggleUI(GameObject targetUI)
    {
        if (selectedUI == null)
        {
            selectedUI = targetUI;
            selectedUI.SetActive(true);
        }
        else if (selectedUI == targetUI)
        {
            if (selectedUI != territoryUI)
            {
                DeselectUI();
            }
        }
        else
        {
            DeselectUI();
            selectedUI = targetUI;
            selectedUI.SetActive(true);
        }
    }

    #region TerritoryUI

    [Header("Territory UI Setup")]
    public TerritoryManager territoryManager;
    public Text territoryName, territoryDescription, territoryTechValue, territoryMoneyValue, territoryOwner;
    public GameObject territoryUI;

    public void TerritoryUISetup()
    {
        if (territoryManager.selectedTerritoryTemplate != null)
        {
            var territoryInformation = territoryManager.selectedTerritoryTemplate.information;

            territoryName.text = "Territory Name: " + territoryInformation.Name;
            territoryDescription.text = "Description:" + territoryInformation.Desc;
            territoryTechValue.text = "Ammount of tech: " + territoryInformation.TechPointValue.ToString();
            territoryMoneyValue.text = "Ammount of money: " + territoryInformation.MoneyValue.ToString();
            territoryOwner.text = "Owner: " + territoryInformation.owner.ToString();
        }
    }
    #endregion

    #region AttackPointsError
    public GameObject attackPointsErrorUI;

    public IEnumerator ShowAttackPointsErrorUI()
    {
        attackPointsErrorUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        attackPointsErrorUI.SetActive(false);
    }
    #endregion

    #region WorldMapUI
    // UI object variables to set active/inactive
    public GameObject techTreeUI;
    public GameObject logUI;

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
    void Start()
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
        turnCounterText.text = "TURN:" + turnCounter.ToString();

        // TODO : next turn logic
        // refresh of the attack points
        Inventory.attackPoints = Inventory.attackPointsLimit;
        attackPointsAmmountText.text = Inventory.attackPoints + "/" + Inventory.attackPointsLimit;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion
}

