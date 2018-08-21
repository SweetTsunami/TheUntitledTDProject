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

public class MiningTower : Structure
{
    public int ammountOfMinedMoney = 10;
    public float rateOfMining = 1;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(StartMining());
    }

    // Update is called once per frame
    void Update()
    {
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
