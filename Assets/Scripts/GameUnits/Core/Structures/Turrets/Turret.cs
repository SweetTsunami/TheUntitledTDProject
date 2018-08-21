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
/// handles the base behavior of turrets
/// </summary>
public class Turret : Structure
{
    /// <summary>
    /// set Tower specific parameters
    ///     range               - diameter size of attack range
    ///     damage              - damage dealt per attack
    ///     fireRate            - frequency of attacks
	///     firePoint			- transform for spawn point of projectiles
	///     slowPct				- slowing ability for turret, slow is in percentil
    /// </summary>
	public enum FirePointSystem { Sequential, Parallel }
    [Header("Turret Properties")]
    public float range = 15f;
    public float projectileDamage = 20f;


	[Range(0f, 4f)]
    public float fireRate = 1f;
	public bool burstFire = false;
	public List<Transform> firePoints = new List<Transform>();
	public FirePointSystem firePointSystem;
	public int selectedFirePoint = 0;
	public float turnSpeed = 50f;

    /// <summary>
    /// setup of unity parameters
    /// </summary>
    [Header("Unity Setup")]
    public Transform partToRotate;
    public string enemyTag = "Enemy";    

    protected Transform target;
	protected Unit targetEnemy;

    void Awake()
    {
        SetUpTheGameUnit();
    }

    /// <summary>
    /// sets method UpdateTarget to repeat
    /// </summary>
    protected override void SetUpTheGameUnit()
    {
        base.SetUpTheGameUnit();
		
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

	/// <summary>
	/// Update target happens every InvokeRepeating value in Start
	/// searches through all enemies, finds those in range, and sets the closest one as a target
	/// </summary>
	protected void UpdateTarget()
	{
		if (node.isPowered)
		{
			// searches through all gameObjects with tag enemyTag
			GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
			// default nearest enemy is null
			GameObject nearestEnemy = null;
			// shortest distance is set to infinity at start so no enemy is further than that
			float shortestDistance = Mathf.Infinity;

			// finds enemy from all enemies, finds it's position, and if it's the closest one, sets it as closest enemy
			foreach (GameObject enemy in enemies)
			{
				float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
				if (distanceToEnemy < shortestDistance)
				{
					shortestDistance = distanceToEnemy;
					nearestEnemy = enemy;
				}
			}

			// if the closest enemy is in range, set it as target, else do nothing
			if (nearestEnemy != null && shortestDistance <= range)
			{
				target = nearestEnemy.transform;
				targetEnemy = nearestEnemy.GetComponent<Unit>();
				LockOnTarget();
			}
			else
			{
				target = null;
			}
		}
	}


    /// <summary>
    /// makes turret look on target
    /// </summary>
    protected void LockOnTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        // y axis is the pointing one atm
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

	/// <summary>
	/// Selects the next firepoint
	/// </summary>
	protected void SelectNextFirePoint()
	{
		if (selectedFirePoint < (firePoints.Count - 1))
		{
			selectedFirePoint++;
		}
		else
		{
			selectedFirePoint = 0;
		}
	}

	/// <summary>
	/// draw the range of tower in red color
	/// </summary>
	protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}