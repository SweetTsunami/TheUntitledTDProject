/*  File:       #SCRIPTNAME#
 *  Creator:    Sweet
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
 
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Tech> ListOfTechs = new List<Tech>();
    public static Inventory playerInventory;

    
    // Use this for initialization
    void Awake()
    {
        MakeThisTheOnlyPlayerInventory();
    }

    void MakeThisTheOnlyPlayerInventory()
    {
        if (playerInventory == null)
        {
            DontDestroyOnLoad(gameObject);
            playerInventory = this;
        }
        else
        {
            if (playerInventory != this)
            {
                Destroy(gameObject);
            }
        }
    }

    #region PlayerStats

    // global (on territory map) resources

     public static int globalMoney;
    public static int techPoints;
    public static int attackPointsLimit = 1;
    public static int attackPoints = attackPointsLimit;
    
    #endregion



#region TechInventory
public bool SearchForTech(Tech techToSearch)
{
    if (ListOfTechs.Contains(techToSearch))
    {
        Debug.Log("searched the list for " + techToSearch + " and found it!");
        return true;
    }
    else
    {
        Debug.Log("searched the list for " + techToSearch + " and didn't find it!");
        return false;
    }
}

public void AddTechToInventory(Tech techToAdd)
{
    if (ListOfTechs.Contains(techToAdd))
    {
        Debug.LogError("This tech is already in the inventory");
    }
    else
    {
        Debug.Log("tech " + techToAdd + " has been added to the player inventory");
        ListOfTechs.Add(techToAdd);
    }
}

public void RemoveTechFromInventory(Tech techToRemove)
{
    if (ListOfTechs.Contains(techToRemove))
    {
        ListOfTechs.Remove(techToRemove);
        Debug.Log(techToRemove.name + " tech have been removed");
    }
    else
    {
        Debug.LogError("there is no such tech");
    }
}
#endregion
}

