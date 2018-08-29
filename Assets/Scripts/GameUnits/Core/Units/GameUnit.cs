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

/// <summary>
/// sets up the base behavior of all gameunits - towers and enemies
/// </summary>
//[RequireComponent(typeof(AudioSource))]
public class GameUnit : MonoBehaviour
{
	// Definition of Enums
	public enum Armor {None,Low,Medium,High,VeryHigh,Invincible };	
	public enum UnitType { Organic, Mechanic}

    /// <summary>
    /// set CoreStats parameters
    ///     maximum      - 100% health 
    ///     current      - actual health
    ///     regeneration - amount of regenerated health
	///     Armor		 - Unity armor level
	///     UnitType	 - Organic / Mechanic
    /// </summary>
    [System.Serializable]
    public class CoreStats
    {
        public float HP_maximum , HP_regeneration, shield;
		public Armor unitArmor;
		public UnitType unitType;

		[HideInInspector]
		public float HP_current;
	}

	// creates health struct
	public CoreStats coreStats;
	public GameObject deathEffect;
	
	[Header("Inventory")]
    protected Inventory inventory;

    private bool isAlive = true;
    void Awake()
    {
        SetUpTheGameUnit();
    }
   
    /// <summary>
    /// Gets the animator
    /// sets the current health to maximum health
    /// </summary>
    protected virtual void SetUpTheGameUnit()
    {
       //  inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
		
        coreStats.HP_current = coreStats.HP_maximum;
    }
    
    /// <summary>
    /// Handles health regeneration
    /// </summary>
    void Update()
    {
        // Handles the regeneration
        if (coreStats.HP_regeneration > 0)
        {
            if (coreStats.HP_current + coreStats.HP_regeneration < coreStats.HP_maximum)
            {
                coreStats.HP_current += coreStats.HP_regeneration;
            }
        }
        Mathf.Clamp(coreStats.HP_current, 0, coreStats.HP_maximum);
    }

    /// <summary>
    /// To be called from other scripts, animations and stuff
    /// </summary>
    protected virtual void Die()
    {        
		Destroy(gameObject);
	}

    /// <summary>
    /// Called when receives damage
    /// </summary>
    /// <param ammount of received damage ="damage"></param>
    public virtual void ReceiveDamage(float damage)
    {
		if (coreStats.shield == 0)
		{
			coreStats.HP_current -= damage;
			if (isAlive && coreStats.HP_current <= 0)
			{
				isAlive = false;
				Die();
			}
		}
		else
		{
			coreStats.shield -= damage;
		}
	}
}

