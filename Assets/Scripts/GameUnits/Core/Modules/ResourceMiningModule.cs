/*  File:       #SCRIPTNAME#
 *  Creator:    Sweet
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */

using UnityEngine;

using System.Collections;

public class ResourceMiningModule : MonoBehaviour
{
    public int ammountOfMinedMoney = 10;
    public float rateOfMining = 1;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(StartMining());
    }

    IEnumerator StartMining()
    {
        yield return new WaitForSeconds(1 / rateOfMining);
        GiveMoney();
        StartCoroutine(StartMining());
    }

    public void GiveMoney()
    {
        GameMaster.Money += ammountOfMinedMoney;
        // TODO spawn cool effect
    }
}
