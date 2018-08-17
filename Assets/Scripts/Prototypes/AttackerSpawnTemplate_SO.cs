/*  File:       #SCRIPTNAME#
 *  Creator:    Sweet
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
 
 using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New wave pattern", menuName = "WavePattern")]
public class AttackerSpawnTemplate_SO : ScriptableObject
{
    public new string name;
    public string description;

    [System.Serializable]
    public class AttackerSetup
    {
        public GameObject attackerPrefab;
        public int ammount;

        [Range(0.5f,2)]
        public float spawnRate = 1.5f;
    }

    [System.Serializable]
    public class WaveSetup
    {
        public List<AttackerSetup> attackerSetup = new List<AttackerSetup>();
    }
    
    public List<WaveSetup> waveSetup = new List<WaveSetup>();    
}
