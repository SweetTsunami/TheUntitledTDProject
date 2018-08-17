/*  File:       TerritoryManager
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

public class TerritoryManager : MonoBehaviour
{
    public TerritoryTemplate_SO selectedTerritoryTemplate;
    public UIManager uiManager;
    
    

    public void SelectTerritory(TerritoryTemplate_SO _territoryTemplate)
    {
        if (selectedTerritoryTemplate == _territoryTemplate)
        {
            selectedTerritoryTemplate = null;
             uiManager.territoryUI.SetActive(false);
            return;
        }

        selectedTerritoryTemplate = _territoryTemplate;
        uiManager.territoryUI.SetActive(true);
    }

    /// <summary>
    /// Attacks the territory if player has enough attack points
    /// </summary>
    public void AttackTheSelectedTerritory()
    {
        if (uiManager.attackPointsErrorUI.activeSelf)
        {
            return;
        }

        // Show error UI if player doesn't have enough points
        if (Inventory.attackPoints == 0)
        {
            StartCoroutine(uiManager.ShowAttackPointsErrorUI());
            return;
        }

        // uses attack point and passes the info about territory to the Inventory
        // Loads the scene of the territory
        Inventory.attackPoints--;

        if (selectedTerritoryTemplate != null)
        {
            GameMaster.territoryMoneyValue = selectedTerritoryTemplate.information.MoneyValue;
            GameMaster.territoryTechValue = selectedTerritoryTemplate.information.TechPointValue;

            uiManager.DeselectUI();
            SceneManager.LoadScene(selectedTerritoryTemplate.information.sceneOfTerritoryIndex);
        }
    }
}