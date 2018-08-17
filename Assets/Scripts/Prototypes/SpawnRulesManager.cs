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

public class SpawnRulesManager : MonoBehaviour
{
    [System.Serializable]
    public class SpawnPointTemplate
    {
        public Transform SpawnPoint;
        public AttackerSpawnTemplate_SO attackerSpawnTemplate;
    }

    [Header("Positions")]
    public Transform targetPoint;
    public List<SpawnPointTemplate> spawnPoints;    
}
