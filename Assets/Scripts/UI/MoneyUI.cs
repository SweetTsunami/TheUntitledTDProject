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

using System.Collections;
using System.Collections.Generic;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;

    void Update ()
    {
        moneyText.text = "" + GameMaster.Money.ToString();
	}
}
