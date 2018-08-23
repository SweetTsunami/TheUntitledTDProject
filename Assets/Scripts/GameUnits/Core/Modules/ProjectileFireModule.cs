/*  File:       ProjectileFireSystem
 *  Creator:   Alexander Semenov
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
using UnityEngine;
 
using System.Collections;
using System.Collections.Generic;

public class ProjectileFireModule : MonoBehaviour
{
	public enum FirePointSystem { Sequential, Parallel, Burst }

	[Header("Fire System Properties")]
	public GameObject projectilePrefab;
	public float projectileDamage = 20f;
	public float projectileAreaOfEffect = 0f;
	public float projectileSpeed = 10f;

	[Range(0f, 4f)]
	public float rateOfFire = 1f;
	protected float cooldown = 0;
	public float range = 15f;

	public Transform partToRotate;
	public float rotationSpeed = 50f;
	public List<Transform> firePoints = new List<Transform>();
	public FirePointSystem firePointSystem;
	public int ammountOfProjectilesInBurst = 0;
	protected int selectedFirePoint = 0;

	public float UpdateFrequency = 0.5f;
	public GameObject target;
	public string GameUnitTag = "GameUnit";

	void Awake()
	{
		//StartCoroutine(UpdateTarget());
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

	private void Update()
	{
		if (target != null && cooldown <= 0f)
		{
			switch (firePointSystem)
			{
				case FirePointSystem.Sequential:
					Shoot();
					break;
				case FirePointSystem.Parallel:
					for (int i = 0; i < firePoints.Count; i++)
					{
						Shoot();
					}
					break;
				case FirePointSystem.Burst:
					for (int i = 0; i < ammountOfProjectilesInBurst; i++)
					{
						Shoot();
					}
					break;

			}
			cooldown = 1f / rateOfFire;
		}
		cooldown -= Time.deltaTime;
	}
	protected void UpdateTarget()
	{
		GameObject[] targetableGameUnits = GameObject.FindGameObjectsWithTag(GameUnitTag);
		GameObject nearestTarget = null;

		float shortestDistance = Mathf.Infinity;

		foreach (GameObject gameUnit in targetableGameUnits)
		{
			float distanceToTarget = Vector3.Distance(transform.position, gameUnit.transform.position);
			if (distanceToTarget < shortestDistance)
			{
				shortestDistance = distanceToTarget;
				nearestTarget = gameUnit;
			}
		}

		if (nearestTarget != null && shortestDistance <= range)
		{
			target = nearestTarget;
			LockOnTarget();
		}
		else
		{
			target = null;
		}
		// yield return new WaitForSeconds(UpdateFrequency);
	}


	/// <summary>
	/// makes turret look on target
	/// </summary>
	protected void LockOnTarget()
	{
		if (target)
		{
			Vector3 direction = target.transform.position - transform.position;
			Quaternion lookRotation = Quaternion.LookRotation(direction);
			Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
			// y axis is the pointing one atm
			partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
		}
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

	protected void Shoot()
	{
		GameObject projectileGO = Instantiate(projectilePrefab, firePoints[selectedFirePoint].position, firePoints[selectedFirePoint].rotation);
		Projectile projectile = projectileGO.GetComponent<Projectile>();

		SelectNextFirePoint();

		//sets the parameters of projectile
		// if there is a projectile, set it's target to the target of tower
		if (projectile != null)
		{
			projectile.SetParameters(projectileDamage, projectileSpeed, projectileAreaOfEffect);
			projectile.SetTarget(target.transform);
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
