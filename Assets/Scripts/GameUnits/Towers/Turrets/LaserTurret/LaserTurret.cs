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

public class LaserTurret : Turret
{
    [Header("Lazer Attributes")]
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;


    void Awake()
    {
        SetUpTheGameUnit();
    }

    protected override void SetUpTheGameUnit()
    {
        base.SetUpTheGameUnit();

        //if (inventory.SearchForTech(usedTechs))
        //{
        //    damage = damage * 2;
        //}
    }
    void Update()
    {
        if (node.isPowered)
        {
            // don't anything if there is no target
            if (target != null)
            {
                Lazer();
            }
            else
            {
                LazerOff();
            }

            //LockOnTarget();
        }
        else
        {
            LazerOff();
        }

    }

    void Lazer()
    {
        //audioSource.clip = shootingSound;
        //audioSource.Play();

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoints[selectedFirePoint].position);
        lineRenderer.SetPosition(1, target.transform.position);

        Vector3 direction = firePoints[selectedFirePoint].position - target.position;

        impactEffect.transform.rotation = Quaternion.LookRotation(direction);
        impactEffect.transform.position = target.position + direction.normalized * 0.5f;

        targetEnemy.ReceiveDamage(projectileDamage * Time.deltaTime);
        targetEnemy.Slow(slowPct);
    }    

    void LazerOff()
    {
        if (lineRenderer.enabled)
        {
            lineRenderer.enabled = false;
            impactEffect.Stop();
            impactLight.enabled = false;
        }
    }
}
