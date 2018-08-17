///*  File:       #SCRIPTNAME#
// *  Creator:    Sweet
// *  Date:       
// *  Location:   Brno, Czech Republic
// *  Project:    
// *  Desc:       
// *  Usage:                  
// */
 
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;

//using System.Collections;

///// <summary>
///// Handles the territory behavior
///// </summary>
//public class TerritoryUI : MonoBehaviour 
//{
//    // sets up the UI 
//    public GameObject territoryUI;
//    public GameObject attackPointsErrorUI;

//    // variable to store territory info
//    public static Territory selectedTerritory;
    

//    [System.Serializable]
//    public struct Information
//    {
//        public Text Name, Desc, Owner, Defense, Resources;
//    }

//    public Information territoryInfoUI;

//    /// <summary>
//    /// sets the target territory and parses the info
//    /// </summary>
//    /// <param name="_target"></param>
//    public void SetTarget(Territory _target)
//    {
//        selectedTerritory = _target;
//        territoryInfoUI.Name.text = "Name: " + selectedTerritory.information.Name;
//        territoryInfoUI.Desc.text = "Description:\n" + selectedTerritory.information.Desc;
//        territoryInfoUI.Owner.text = "Owner: " + selectedTerritory.information.Owner;
//        territoryInfoUI.Defense.text = "Defense: " + selectedTerritory.information.Defense;
//        territoryInfoUI.Resources.text = "Resources: " + selectedTerritory.information.Resources;

//        ToggleTerritoryUI();
//    }

//    public void ToggleTerritoryUI()
//    {
//        territoryUI.transform.position = selectedTerritory.transform.position;
//        territoryUI.SetActive(!territoryUI.activeSelf);
//    }
    
//    IEnumerator ShowAttackPointsErrorUI()
//    {
//        attackPointsErrorUI.SetActive(true);
//        yield return new WaitForSeconds(2f);
//        attackPointsErrorUI.SetActive(false);
//    }

//    /// <summary>
//    /// Attacks the territory if player has enough attack points
//    /// </summary>
//    public void Attack()
//    {
//        if (attackPointsErrorUI.activeSelf)
//        {
//            return;
//        }

//        // Show error UI if player doesn't have enough points
//        if (Inventory.attackPoints == 0)
//        {
//            ToggleTerritoryUI();
//            StartCoroutine(ShowAttackPointsErrorUI());
//            return;
//        }
        
//        // uses attack point and passes the info about territory to the Inventory
//        // Loads the scene of the territory
//        Inventory.attackPoints--;

//        GameMaster.territoryMoneyValue = selectedTerritory.information.MoneyValue;
//        GameMaster.territoryTechValue = selectedTerritory.information.TechPointValue;

//        SceneManager.LoadScene(selectedTerritory.buildSceneIndex);       
//    }
//}
