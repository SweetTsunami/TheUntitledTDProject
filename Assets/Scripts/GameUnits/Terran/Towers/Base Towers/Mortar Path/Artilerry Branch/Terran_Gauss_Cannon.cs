/*  File:       Terran_Mortar
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

public class Terran_Gauss_Cannon : ProjectileTurret
{
	[Header("Animations")]
	// public HealthBar healthBar;

	// creates animator, which handles animations
	private Animator animator;

	[Header("Sounds")]
	public AudioClip receivedDamageSound;
	public AudioClip deathSound;
	public AudioClip shootingSound;
	protected AudioSource audioSource;

	private void Start()
	{		
        animator = GetComponent<Animator>();

		if (inventory.SearchForTech(usedTechs) == true)
		{
			// do flame pool
		}
	}

	protected override void Die()
	{

		//audioSource.clip = deathSound;
		//audioSource.Play();
		base.Die();
		GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);

		Destroy(effect);
	}
}
