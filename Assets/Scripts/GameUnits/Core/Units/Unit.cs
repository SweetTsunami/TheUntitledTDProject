/*  File:       #SCRIPTNAME#
 *  Creator:    Sweet
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
 
using UnityEngine;
using Pathfinding;

/// <summary>
/// Handles the base behavior of attackers
/// movement speed of attacker is in Nav agent
/// </summary>
public class Unit : GameUnit
{
    /// <summary>
    /// target          - target destination of enemy
    /// aiPath          - the script for pathing
    /// </summary>
    protected Transform target;
	protected AIDestinationSetter aiPath;
	
    // speed of enemy
    public float speed = 10f;

    /// <summary>
    /// gets the aiPath component before start
    /// </summary>
    void Awake ()
    {
        GameMaster.ammountOfAttackersInScene++;
        Debug.Log(gameObject + " spawned, raising attacker count to " + GameMaster.ammountOfAttackersInScene);
        SetUpTheGameUnit();
    }

    protected override void SetUpTheGameUnit()
    {
        base.SetUpTheGameUnit();

        aiPath = GetComponent<AIDestinationSetter>();
        aiPath.newSpeed = speed;
    }
    public void Slow(float pct)
    {
		aiPath.newSpeed = speed * (1f - pct);
    }

    /// <summary>
    /// Sets the current target for enemy to move towards
    /// gets the target from WaveSpawner script
    /// </summary>
    /// <param target destination ="_target"></param>
    public void SetTarget(Transform _target)
    {
        target = _target;
        aiPath.target = target;
    }

    /// <summary>
    /// When enemy reaches the end of path, reduce the ammount of lives and Die()
    /// </summary>
    public void EndPath()
    {
        GameMaster.PlayerHealth--;
		Die();
    }

    protected override void Die()
    {
        GameMaster.ammountOfAttackersInScene--;
        Debug.Log(gameObject + " died, lowering attacker count to " + GameMaster.ammountOfAttackersInScene);

        base.Die();
    }
}
