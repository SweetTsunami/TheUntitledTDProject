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

public class AnotherShootingAttacker : ShootingAttacker
{
    protected override void Update()
    {
        if (shootingTarget == null)
        {
            aiPath.speed = speed;
            return;
        }


        LockOnTarget();

        // attacker shoots when it's off cooldown        
        if (cooldown <= 0f)
        {
            aiPath.speed = 0;
            Shoot();
            cooldown = 1f / fireRate;
        }

        cooldown -= Time.deltaTime;
    }
}
