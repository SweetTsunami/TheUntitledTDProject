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

/// <summary>
/// Core script for handling stuff in the game (actual game with towers, not territory)
/// </summary>
public class GameMaster : MonoBehaviour
{
    // I changed something else again
    // setup of UI for endings
    public GameObject gameOverUI;
    public GameObject winUI;

    // teritory info
    public static int territoryMoneyValue;
    public static int territoryTechValue;
    //public static Territory selectedTerritory;

    //// Difficulty setup
    //public enum Difficulty { Easy, Medium, Hard };
    //public static Difficulty selectedDifficulty;

    // info about players ingame money
    public static int Money;
    public int startMoney = 100;

    // info about player's ingame health (possible redesign here)
    public static int PlayerHealth;
    public int startPlayerHealth = 20;

    // handles ammount of attackers in scene 
    public static int ammountOfAttackersInScene;

    // switch for game mechanics
    public static bool gameEnded;

    // first wave countdown and it's text variables
    public Text waveCountdownText;
    public float waveCountdownAtStart;
    public static float waveCountdown;

    // ammount of time between waves
    public float ammountOfTimeBetweenWavesAtStart;
    public static float ammountOfTimeBetweenWaves;

    // text field for index of the wave
    public Text waveIndexText;
    
    // count of round
    public static int Round = 0;
    public static int MaxRound = 0;

    /// <summary>
    /// Sets the static variables and some more, for the case when game restarts
    /// </summary>
	void OnEnable()
    {
        Money = startMoney;
        PlayerHealth = startPlayerHealth;
        ammountOfTimeBetweenWaves = ammountOfTimeBetweenWavesAtStart;
        waveCountdown = waveCountdownAtStart;

        gameEnded = false;

        
        Round = 0;
    }

	void Update()
	{
		if (gameEnded)
			return;
        
        // game is over if player has no health
        if (PlayerHealth <= 0)
        {
            GameOver();
            return;
        }
        
        if (WaveSpawner.state == WaveSpawner.SpawnerState.FINISHED)
        {
            Win();
            return;
        }
        
        // handles the next wave countdown
        waveCountdown -= Time.deltaTime;
        waveCountdown = Mathf.Clamp(waveCountdown, 0f, Mathf.Infinity);

        // updates the text fields
        waveIndexText.text = Round.ToString() + " / " + MaxRound.ToString();
		waveCountdownText.text = string.Format("{0:00.00}", waveCountdown);

        
        // my hotkeys
		if (Input.GetKeyDown("e"))
		{
			GameOver();
		}

        if (Input.GetKeyDown("w"))
        {
            Win();
        }
	}

    /// <summary>
    /// Handles the GameOver scenario
    /// </summary>
    public void GameOver()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }

    /// <summary>
    /// Handles the GameWin scenario
    /// </summary>
    public void Win()
    {
        gameEnded = true;
        winUI.SetActive(true);
        Inventory.techPoints += territoryTechValue;
        Inventory.globalMoney += territoryMoneyValue;
    }
}