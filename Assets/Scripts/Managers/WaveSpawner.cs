/*  File:       WaveSpawner
 *  Creator:    Sweet
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       Class responsible for spawning waves in proper manner on correct spawnpoints
 *  Usage:              
 */

using UnityEngine;

using System.Collections;

/// <summary>
/// Class responsible for spawning waves in proper manner on correct spawnpoints
/// </summary>
public class WaveSpawner : MonoBehaviour
{
    /// <summary>
    /// Different states control the flow of the spawning.
    /// </summary>
    public enum SpawnerState
    {
        SPAWNING, WAITING, COUNTDOWN, FINISHED
    };
    
    // Required component to properly fill the wavespawner with wave templates.
    private SpawnRulesManager spawnRulesManager;
    
    // Initial setup of state.
    public static SpawnerState state = SpawnerState.COUNTDOWN;

    /// <summary>
    /// Gets components, determines largest template (biggest ammount of waves) to set final wave.
    /// </summary>
    private void OnEnable()
    {        
        spawnRulesManager = GetComponent<SpawnRulesManager>();
        GameMaster.MaxRound = DetermineLargestTemplate();
        Debug.Log("Ammount of waves in this game : " + GameMaster.MaxRound);
    }

    /// <summary>
    /// Conditions and loops to properly spawn attackers.
    /// </summary>
    void Update()
    {
        // InvokeRepeating("EnemyCount", 5.0f,5.0f);
        // Don't do anything if the game is ended.
        if (state == SpawnerState.FINISHED)
        {
            return;
        }

        // If no attackers are alive, complete the wave, or return to the start of Update.
        if (state == SpawnerState.WAITING)
        {
            // Debug.Log("Ammount of attackers left (before waiting check): " + GameMaster.ammountOfAttackersInScene);

            if (!IsAnyAttackerAlive())
            {
                Debug.Log("No attackers found, wave completed");

                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        // When countdown reaches zero, start spawning the next wave.
        if (GameMaster.waveCountdown <= 0)
        {
            if (state != SpawnerState.SPAWNING)
            {
                foreach (SpawnRulesManager.SpawnPointTemplate spawnPoint in spawnRulesManager.spawnPoints)
                {
                    if (GameMaster.Round < spawnPoint.attackerSpawnTemplate.waveSetup.Count)
                    {
                        StartCoroutine(SpawnWaveAtIndex(GameMaster.Round , spawnPoint));
                    }                  
                }
            }
        }

        // Or if it's not zero, start counting down.
        else
        {
            GameMaster.waveCountdown -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Finds out the largest template and sets it's ammount of waves as max waves.
    /// </summary>
    /// <returns></returns>
    int DetermineLargestTemplate()
    {
        int largestTemplate = 0;
        foreach (SpawnRulesManager.SpawnPointTemplate template in spawnRulesManager.spawnPoints)
        {
            var templateWaveSetup = template.attackerSpawnTemplate.waveSetup;

            if (templateWaveSetup.Count < largestTemplate)
            {
                Debug.Log("OLD WAVE TEMPLATE SIZE " + templateWaveSetup.Count);
                for (int i = templateWaveSetup.Count; i <= largestTemplate; i++)
                {
                    templateWaveSetup.Add(new AttackerSpawnTemplate_SO.WaveSetup());
                }
                Debug.Log("NEW WAVE TEMPLATE SIZE " + templateWaveSetup.Count);
            }

            if (templateWaveSetup.Count > largestTemplate)
            {
                largestTemplate = templateWaveSetup.Count;                
            }
        }
        return largestTemplate;
    }

    /// <summary>
    /// Handles the finished wave, sets the round to the next one, if it's last, finish the game
    /// #COMPLETE THIS (GAMEMASTER SCRIPT - Update() {if round > maxround) win the game
    /// </summary>
    void WaveCompleted()
    {
        state = SpawnerState.COUNTDOWN;
        Debug.Log("WaveSpawner state: " + state);

        GameMaster.waveCountdown = GameMaster.ammountOfTimeBetweenWaves;

        if (GameMaster.Round < GameMaster.MaxRound)
        {
            GameMaster.Round++;
            GameMaster.waveCountdown = GameMaster.ammountOfTimeBetweenWaves;
            if (GameMaster.Round == GameMaster.MaxRound)
            {
                Debug.Log("Last round completed! GG");
            }
            else
            {
                Debug.Log("Wave completed, setting the game round to the : " + GameMaster.Round);
            }
        }

        if (!IsAnyAttackerAlive())
        {
            if (GameMaster.Round == GameMaster.MaxRound)
            {
                state = SpawnerState.FINISHED;
                Debug.Log("WaveSpawner state: " + state);
            }
        }
    }
    /// <summary>
    /// Simple check if there are attackers alive on the map (GameUnit.Start contains ++ and .Die --)
    /// </summary>
    /// <returns></returns>
    bool IsAnyAttackerAlive()
    {
        if (GameMaster.ammountOfAttackersInScene == 0)
        {
            return false;
        }
        
        return true;
    }

    /// <summary>
    /// For keeping track of stuff
    /// </summary>
    void EnemyCount()
    {
        Debug.Log("Ammount of attackers left: " + GameMaster.ammountOfAttackersInScene);
    }

    /// <summary>
    /// IEnumerator to utilize yield waitforseconds, so the rate of spawn will be managable
    /// </summary>
    /// <param name="waveIndex">Index of the spawned wave in the template</param>
    /// <param name="spawnPoint">Template of the spawn point</param>
    /// <returns>Spawns the wave of attackers</returns>
    IEnumerator SpawnWaveAtIndex(int waveIndex, SpawnRulesManager.SpawnPointTemplate spawnPoint)
    {
        state = SpawnerState.SPAWNING;
        Debug.Log("WaveSpawner state: " + state);
        Debug.Log("waveIndex : " + waveIndex);
        
        var attackerSetup = spawnPoint.attackerSpawnTemplate.waveSetup[waveIndex].attackerSetup;

        for (int attackerIndex = 0; attackerIndex < attackerSetup.Count; attackerIndex++)
        {
            // Debug.Log("Spawning attacker #:" + attackerIndex);
            for (int attacker = 0; attacker < attackerSetup[attackerIndex].ammount; attacker++)
            {
                // Debug.Log("Spawning : " + attackerSetup[attackerIndex].attackerPrefab);
                SpawnAttacker(attackerSetup[attackerIndex].attackerPrefab, spawnPoint.SpawnPoint,spawnPoint.SpawnPoint.rotation);
                yield return new WaitForSeconds(1f / attackerSetup[attackerIndex].spawnRate);
            }
        }

        Debug.Log("WaveSpawner state: " + state);
        state = SpawnerState.WAITING;
        yield break;
    }

    /// <summary>
    /// Spawns Attacker
    /// </summary>
    /// <param name="attackerPrefab">The Prefab of attacker</param>
    /// <param name="spawnPoint">Spawn point on which it should be spawned</param>
    /// <param name="rotation">Rotation of the spawns point</param>
    void SpawnAttacker(GameObject attackerPrefab, Transform spawnPoint,Quaternion rotation)
    {
        GameObject enemyGO = Instantiate(attackerPrefab, spawnPoint.position, transform.rotation);
        Unit attacker = enemyGO.GetComponent<Unit>();
        attacker.SetTarget(spawnRulesManager.targetPoint.transform);
    }
}
