/*  File:       #SCRIPTNAME#
 *  Creator:    Sweet
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
 
using UnityEngine;

public class ShootingAttacker : Attacker
{
    /// <summary>
    /// set shooting attacker specific parameters
    ///     range               - diameter size of attack range
    ///     damage              - damage dealt per attack
    ///     fireRate            - frequency of attacks
    ///     firePoint			- transform for spawn point of projectiles
    /// </summary>
    [Header("Shooting Attacker Attributes")]
    public float range = 10f;
    public float damage = 10f;
    public float fireRate = 1f;
    public Transform firePoint;
    public float turnSpeed = 10f;
    
    /// <summary>
    /// setup of projectiles attacker fires
    ///     projectileSpeed     - movement speed of projectiles
    ///     turnSpeed           - speed of tower turning
    /// </summary>
    [Header("Projectile Attributes")]
    public float projectileExplosionRadius = 0f;
    public float projectileSpeed = 10f;

    // cooldown before enemy can fire again, initalized at 0 so it can fire right away
    protected float cooldown = 0;

    public GameObject bulletPrefab;

    /// <summary>
    /// setup of unity parameters
    /// </summary>
    [Header("Unity Setup")]
    //protected AudioSource audioSource;
    public Transform partToRotate;
    public string enemyTag = "Turret";

    public Transform shootingTarget;
    public GameUnit targetEnemy;

    /// <summary>
    /// sets method UpdateTarget to repeat
    /// </summary>
    protected virtual void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    protected virtual void Update()
    {
        if (shootingTarget == null)
        {
            return;
        }

        LockOnTarget();

        // attacker shoots when it's off cooldown        
        if (cooldown <= 0f)
        {
            Shoot();
            cooldown = 1f / fireRate;
        }

        cooldown -= Time.deltaTime;
    }

    /// <summary>
    /// Update shootingTarget happens every InvokeRepeating value in Start
    /// searches through all enemies, finds those in range, and sets the closest one as a target
    /// </summary>
    protected void UpdateTarget()
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

        // if the closest enemy is in range, set it as shootingTarget, else do nothing
        if (nearestEnemy != null && shortestDistance <= range)
        {
             shootingTarget = nearestEnemy.transform;
             targetEnemy = nearestEnemy.GetComponent<GameUnit>();
        }
        else
        {
            shootingTarget = null;
        }
    }

    /// <summary>
    /// makes the enemy look at enemy
    /// </summary>
    protected void LockOnTarget()
    {
        Vector3 direction = shootingTarget.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        // y axis is the pointing one atm
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    
    /// <summary>
	/// create projectile and set it's target
	/// </summary>
	protected void Shoot()
    {
        //audioSource.clip = shootingSound;
        //audioSource.Play();

        GameObject projectileGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        //sets the parameters of projectile
        // if there is a projectile, set it's target to the target of tower
        if (projectile != null)
        {
            projectile.SetParameters(damage, projectileSpeed, projectileExplosionRadius);
            projectile.SetTarget(shootingTarget);
        }
    }

    /// <summary>
    /// Draws the range of enemies
    /// </summary>
    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
