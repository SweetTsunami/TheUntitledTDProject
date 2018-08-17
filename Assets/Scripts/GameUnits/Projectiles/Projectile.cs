/*  File:       #SCRIPTNAME#
 *  Creator:    Sweet
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
 
using UnityEngine;

using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Handles the base behavior of projectiles
/// </summary>
public class Projectile : MonoBehaviour
{
	public enum DamageType { Laser, Incendinary, Explosive, EMP, Other }

	/// <summary>
	/// sets the parameters of projectile
	///     damage           - amount of damage passed from tower, inflicts this amount on impact
	///     speed            - speed of the projectile is also passed from tower, defines movement speed
	///     explosionRadius  - radius of explosion, if set to 0, no explosion occurs
	/// </summary>
	private float damage = 0, speed = 10, explosionRadius = 0f;
	public DamageType damageType;
    public void SetParameters(float _damage, float _speed, float _explosionRadius)
    {
        damage = _damage;
		speed = _speed;
        explosionRadius = _explosionRadius;
    }

    // target coordinates
    private Transform target;
    // sets the visual effect of impact
    public GameObject impactEffect;    
	
    /// <summary>
    /// handles direction and movement of projectile
    /// Calls HitTarget if it hits target
    /// </summary>
	void Update ()
    {
        // if there is no target, destroy the projectile
		if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        // set the direction of projectile
        Vector3 direction = target.position - transform.position;

        // check the distance projectile moved this frame
        float distanceThisFrame = speed * Time.deltaTime;

        // check if the projectile hit the target
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        // move the projectile
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        // point projectile towards target
        transform.LookAt(target);
    }

    /// <summary>
    /// what to do when the target is hit
    /// it's virtual so a child script can override it
    /// </summary>
    virtual public void HitTarget()
    {
        // create effect and destroy it 
        GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1f);
        
        // if the projectile has AoE damage, goes to the explode, if not, goes to Damage
        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        // destroy the projectile after it hits the target
        Destroy(gameObject);
    }

	/// <summary>
	/// handles the damage of projectile
	/// </summary>
	/// <param traget of projectile ="enemy"></param>
	void Damage(Transform enemy)
	{
		GameUnit e = enemy.GetComponent<GameUnit>();
		if (e != null)
		{
			if (e.coreStats.shield > 0)
			{
				switch (damageType)
				{
					case DamageType.Laser:
						e.ReceiveDamage(damage);
						break;
					case DamageType.Explosive:
						e.ReceiveDamage(damage * 0.5f);
						break;
					case DamageType.Incendinary:
						e.ReceiveDamage(0);
						break;
					case DamageType.EMP:
						e.ReceiveDamage(damage * 2.0f);
						break;
					case DamageType.Other:
						e.ReceiveDamage(damage);
						break;
					default:
						e.ReceiveDamage(damage);
						break;
				}
			}
			else
			{
				if (e.coreStats.unitType == GameUnit.UnitType.Organic)
				{
					switch (damageType)
					{
						case DamageType.Laser:
							e.ReceiveDamage(damage);
							break;
						case DamageType.Explosive:
							e.ReceiveDamage(damage * 1.2f);
							break;
						case DamageType.Incendinary:
							e.ReceiveDamage(damage * 1.5f);
							break;
						case DamageType.EMP:
							e.ReceiveDamage(0);
							break;
						case DamageType.Other:
							e.ReceiveDamage(damage);
							break;
						default:
							e.ReceiveDamage(damage);
							break;
					}
				}
				else if (e.coreStats.unitType == GameUnit.UnitType.Mechanic)
				{
					switch (damageType)
					{
						case DamageType.Laser:
							e.ReceiveDamage(damage);
							break;
						case DamageType.Explosive:
							e.ReceiveDamage(damage * 1.2f);
							break;
						case DamageType.Incendinary:
							e.ReceiveDamage(damage * 0.8f);
							break;
						case DamageType.EMP:
							e.ReceiveDamage(damage * 0.5f);
							break;
						case DamageType.Other:
							e.ReceiveDamage(damage);
							break;
						default:
							e.ReceiveDamage(damage);
							break;
					}
				}
			}
		}
	}
    

    /// <summary>
    /// creates a sphere with radius of explosionRadius
    /// damages every enemy in radius
    /// </summary>
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    /// <summary>
    /// set target and it's coordinates
    /// </summary>
    /// <param name="target"></param>
    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    /// <summary>
    /// if the projectile has AoE efect, draw it's radius in editor
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
