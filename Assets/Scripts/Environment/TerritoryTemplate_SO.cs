/*  File:       TerritoryTemplate_SO
 *  Creator:    Sweet
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
 
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Territory", menuName = "Territory")]
public class TerritoryTemplate_SO : ScriptableObject
{
    public enum Owner { PLAYER, ENEMY, UNCLAIMED };
        
    [System.Serializable]
    public class Information
    {
        public string Name, Desc;
        public int TechPointValue, MoneyValue;
        public int sceneOfTerritoryIndex;
        public Owner owner;
    }

    public Information information;

}
