/*  File:       UIManager_battle
 *  Creator:   Alexander Semenov
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIManager_battle : UIManager
{
	public static Node SelectedNode;
	//public List<StructureBlueprint> structureBlueprints = new List<StructureBlueprint>();

	// UI setup
	public GameObject structureShopUI;
	public GameObject structureMenuUI;

	private void Awake()
	{	
		SelectedNode = null;
	}

	private void Update()
	{
		if (SelectedNode)
		{
			MoveUI(SelectedNode.transform);
			if (SelectedNode.populated)
			{
				ToggleUI(structureMenuUI);
			}

			else
			{
				ToggleUI(structureShopUI);
			}
		}
		else
		{
			DeselectUI();
		}
	}	
}
