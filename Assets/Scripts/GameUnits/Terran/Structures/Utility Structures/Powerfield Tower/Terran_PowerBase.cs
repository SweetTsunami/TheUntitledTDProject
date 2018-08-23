using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terran_PowerBase : Structure
{
	protected PowerGeneratorModule powerGeneratorModule;

	private void Awake()
	{
		powerGeneratorModule = gameObject.GetComponent<PowerGeneratorModule>();
		
	}
}
