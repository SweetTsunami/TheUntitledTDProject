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

///// <summary>
///// setups the behaviour of ShopUI
///// </summary>
//public class TowerShop : MonoBehaviour
//{
//    /// <summary>
//    /// put buildable turrets here
//    /// </summary>
//    /// 
//    //[Header("Tower Shop")]
//    //public GameObject[] tower;

//    [System.Serializable]
//    public struct TowerBlueprint
//    {
//        public string name;
//        public string description;
//        public GameObject prefab;
//    }
//    public TowerBlueprint[] towerBlueprints;
//    /// <summary>
//    /// Different effects should be here
//    /// </summary>
//    [Header("Effects")]
//    public GameObject buildEffect;
//    public GameObject upgradeEffect;

//    // UI setup
//    public GameObject towerShopUI;
//    public GameObject towerMenuUI;

//    public Button miningTowerButton;
    
//    /// <summary>
//    /// These two are required to properly handle the turret placement 
//    /// and give node
//    /// </summary>
//    [HideInInspector]
//    public GameObject towerGO;
//    [HideInInspector]
//    public static Node SelectedNode;
    
//    /// <summary>
//    /// Finds the tower of index in the array, which is set-up in ShopUI script.
//    /// returns if player doesn't have enough money
//    /// instantiates tower on the node and gets it's Tower component, then links the tower to the node
//    /// sets node to populated and changes it's layer to obstacles, so others won't walk thrugh it
//    /// </summary>
//    /// <param This parameter is set on button which builds the turret="index"></param>
//    public void BuildTower(int index)
//    {        
//        // Finds the tower
//        GameObject towerToBuildGO = towerBlueprints[index].prefab;
//        Structure towerToBuild = towerToBuildGO.GetComponent<Structure>();

//        // Money check
//        if (GameMaster.Money < towerToBuild.buildCost)
//        {
//            // TODO spawn UI not enough money
//            Debug.Log("Not enough money to build, need " + (towerToBuild.buildCost - GameMaster.Money) + " more");
//            return;
//        }
//        GameMaster.Money -= towerToBuild.buildCost;

//        // Instantiates tower on node and gets it's Tower component so it's possible to link them
//        towerGO =  Instantiate(towerToBuildGO, SelectedNode.GetBuildPosition(), Quaternion.identity);
//        Structure spawnedTower = towerGO.GetComponent<Structure>();
//        spawnedTower.LinkNode(SelectedNode);

//        // changes to node
//        SelectedNode.populated = true;
//        DeselectNode();
//        SelectedNode.gameObject.layer = LayerMask.NameToLayer("Obstacles");

//        // spawns cool effect
//        GameObject towerBuiltEffect = Instantiate(buildEffect, SelectedNode.transform.position, Quaternion.identity);
//        Destroy(towerBuiltEffect, 1f);
//    }

//    /// <summary>
//    /// Finds the prefab of upgraded version by checking the current version of tower
//    /// returns if player doesn't have enough money
//    /// destroys previous tower to make space for the upgraded one
//    /// instantiates upgraded version, gets it's Tower component and links it to the node
//    /// </summary>
//    public void UpgradeTower(int index)
//    {
//        // Find the prefab to build
//        GameObject towerToBuildGO = SelectedNode.structureOnThisNode.UpgradedStructuresPrefabs[index];
//        Structure towerToBuild = towerToBuildGO.GetComponent<Structure>();

//        if (GameMaster.Money < towerToBuild.buildCost)
//        {
//            // TODO spawn UI not enough money
//            Debug.Log("Not enough money to upgrade, need " + (towerToBuild.buildCost - GameMaster.Money) + " more");
//            return;
//        }
//        GameMaster.Money -= towerToBuild.buildCost;

//        // get rid of old tower
//        towerGO = SelectedNode.structureOnThisNode.gameObject;
//        Destroy(towerGO);

//        // build new one
//        towerGO = Instantiate(towerToBuildGO, SelectedNode.GetBuildPosition(), Quaternion.identity);
//        Structure spawnedTower = towerGO.GetComponent<Structure>();
//        spawnedTower.LinkNode(SelectedNode);

//        DeselectNode();

//        // spawns cool effect
//        GameObject towerUpgradeEffect = Instantiate(upgradeEffect, SelectedNode.transform.position, Quaternion.identity);
//        Destroy(towerUpgradeEffect, 1f);        
//    }

//    /// <summary>
//    /// Refunds some money for the turret
//    /// destroys the prefab which is linked to the selected node
//    /// changes node layer to Envirovment, so others can walk on it
//    /// </summary>
//    public void SellTower()
//    {
//        // add money
//        GameMaster.Money += SelectedNode.structureOnThisNode.sellCost;

//        // get rid of tower
//        Destroy(towerGO);

//        // changes to node
//        SelectedNode.populated = false;
//        DeselectNode();
//        SelectedNode.gameObject.layer = LayerMask.NameToLayer("Envirovment");
//    }

//    public void SelectNode(Node node)
//    {
//        SelectedNode = node;
//        MoveUI();
//        // show ShopUI if the node is populated
//        if (node.populated)
//        {
//            // gives tower on node information to towerShop

//            // turns on correct UI menu
//            DeselectNode();
//            towerMenuUI.SetActive(true);
//        }

//        else
//        {
//            // turns on correct UI menu
//            DeselectNode();
//            towerShopUI.SetActive(true);
//            if (SelectedNode.minable)
//            {
//                miningTowerButton.interactable = true;
//            }
//            else
//            {
//                miningTowerButton.interactable = false;
//            }
//        }
//    }

//    /// <summary>
//    /// removes the tower and shop UI's so it basically deselects the node
//    /// </summary>
//    public void DeselectNode()
//    {
//        towerMenuUI.SetActive(false);
//        towerShopUI.SetActive(false);
//    }

//    public void MoveUI()
//    {
//        // move UI's to the node position (with offset to make it more visible)
//        towerShopUI.transform.position = SelectedNode.GetBuildPosition() + new Vector3(0, 2, 0);
//        towerMenuUI.transform.position = SelectedNode.GetBuildPosition() + new Vector3(0, 2, 0);
//    }
//}
