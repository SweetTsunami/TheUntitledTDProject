/*  File:       #SCRIPTNAME#
 *  Creator:    Sweet
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
 
 //using UnityEngine;

//using System.Collections;

///// <summary>
///// handles the behavior of wave spawner, and spawned enemies
///// </summary>
//public class WaveSpawner_old : MonoBehaviour
//{
//    // setup of waves
//    public Wave[] waves;
//    // sets the destination for spawned enemies
//    public Transform targetPoint;

//    void Start()
//    {
//        // throw warning if ammount of waves in spawer is different than total ammount of waves in scene
//        // unused waves should be empty so it makes more sense
//        // TODO: room for improvement here !
//        if (waves.Length != GameMaster.ammountOfWavesInScene)
//        {
//            Debug.LogWarning(this.name + " wave spawner contains different ammount of waves than specified in GameMaster");
//        }
//    }

//    // don't know better workaround
//    public void StartWaveSpawning()
//    {
//        if (GameMaster.Round >= GameMaster.ammountOfWavesInScene)
//        {
//            return;
//        }
//        StartCoroutine(SpawnWave());
//    }

//    /// <summary>
//    /// spawns waves, IEnumerator is used, because it's called every few seconds
//    /// </summary>
//    IEnumerator SpawnWave()
//    {

//        Wave wave = waves[GameMaster.Round];
//        // spawns i enemies
//        for (int i = 0; i < wave.ammountOfAttackers; i++)
//        {
//            SpawnEnemy(wave.attackerPrefab);
//            yield return new WaitForSeconds(1f / wave.rate);
//        }

//        if (GameMaster.Round == waves.Length)
//        {
//            this.enabled = false;
//        }
//    }

//    /// <summary>
//    /// spawns the enemy and sets it's target to target of wave spawner
//    /// </summary>
//    void SpawnEnemy(GameObject enemyPrefab)
//    {
//        GameObject enemyGO = Instantiate(enemyPrefab, transform.position, transform.rotation);
//        Attacker attacker = enemyGO.GetComponent<Attacker>();
//        attacker.SetTarget(targetPoint.transform);
//    }
//}
