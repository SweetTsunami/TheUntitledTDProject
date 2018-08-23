using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terran_MiningBase : Structure
{
	protected ResourceMiningModule resourceMiningModule;
	public GameObject RocketPlatformObject;
	public Tech DefenseModuleTech;

	private void Awake()
	{
		resourceMiningModule = gameObject.GetComponent<ResourceMiningModule>();
		if (inventory.SearchForTech(DefenseModuleTech))
		{
			RocketPlatformObject.SetActive(true);
		}
	}
}
