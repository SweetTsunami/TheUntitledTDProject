/*  File:       #SCRIPTNAME#
 *  Creator:    Sweet
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
 
 using UnityEngine;

[CreateAssetMenu(fileName = "New Tech", menuName = "Tech")]
public class Tech : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite artwork;

    public int techCost;
}