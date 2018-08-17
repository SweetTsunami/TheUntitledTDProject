/*  File:       TerritoryUI_New
 *  Creator:    Sweet
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
 
using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class TerritoryUI_New : MonoBehaviour 
{    
    public Text territoryName, territoryDescription, territoryTechPointValue, territoryMoneyValue, territoryOwner;


    public TerritoryManager territoryManager;

    void Start()
    {
        SetupUI();
    }

    void SetupUI()
    {
        var territoryInformation = territoryManager.selectedTerritoryTemplate.information;

        territoryName.text = territoryInformation.Name;
        territoryDescription.text = territoryInformation.Desc;
        territoryTechPointValue.text = territoryInformation.TechPointValue.ToString();
        territoryMoneyValue.text = territoryInformation.MoneyValue.ToString();
        territoryOwner.text = territoryInformation.owner.ToString();

    }
}
