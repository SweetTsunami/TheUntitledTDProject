/*  File:       #SCRIPTNAME#
 *  Creator:    Sweet
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
 
 using UnityEngine;

public class ProjectileTurret : Turret 
{

	/// <summary>
	/// setup of projectiles tower fires
	///     projectileSpeed     - movement speed of projectiles
	///     turnSpeed           - speed of tower turning
	/// </summary>
	[Header("Projectile Attributes")]
	public float projectileExplosionRadius = 0f;
	public float projectileSpeed = 10f;
	public GameObject projectilePrefab;

	// cooldown before tower can fire again, initalized at 0 so it can fire right away
	protected float cooldown = 0;

    /// <summary>
    /// tower shoots when it's off cooldown        
    /// </summary>
	void Update()
	{
        if (node.isPowered )
        {
            if (target != null)
            {
                if (cooldown <= 0f)
                {
                    ShootMode();
                    cooldown = 1f / fireRate;
                }
            }
        }
		cooldown -= Time.deltaTime;
	}

	protected void ShootMode()
	{
		if (firePointSystem == FirePointSystem.Sequential)
		{
			Shoot();
		}
		else if(firePointSystem == FirePointSystem.Parallel)
		{
			for (int i = 0; i < firePoints.Count; i++)
			{
				Shoot();
			}
		}
	}

	/// <summary>
	/// create projectile and set it's target
	/// </summary>
	protected void Shoot()
	{
		//audioSource.clip = shootingSound;
		//audioSource.Play();
		GameObject projectileGO = Instantiate(projectilePrefab, firePoints[selectedFirePoint].position, firePoints[selectedFirePoint].rotation);
		Projectile projectile = projectileGO.GetComponent<Projectile>();
		SelectNextFirePoint();

		//sets the parameters of projectile
		// if there is a projectile, set it's target to the target of tower
		if (projectile != null)
		{
			projectile.SetParameters(projectileDamage, projectileSpeed, projectileExplosionRadius);
			projectile.SetTarget(target);
		}
	}
}
