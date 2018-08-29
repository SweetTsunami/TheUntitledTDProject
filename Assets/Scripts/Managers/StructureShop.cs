using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StructureBuilder))]
public class StructureShop : MonoBehaviour
{
	public List<StructureBlueprint> structureBlueprints = new List<StructureBlueprint>();
	public StructureBuilder structureBuilder;

	private void Awake()
	{
		structureBuilder = gameObject.GetComponent<StructureBuilder>();
	}

	public void BuyStructure(StructureBlueprint _structureBlueprint)
	{
		if (HasMoneys(_structureBlueprint.buildCost))
		{
			GameMaster.Money -= _structureBlueprint.buildCost;

			structureBuilder.BuildStructure(_structureBlueprint, UIManager_battle.SelectedNode);
		}
	}

	public void SellStructure(Node selectedNode)
	{
		
	}

	public bool HasMoneys(int buildCost)
	{
		if (GameMaster.Money < buildCost)
		{
			Debug.Log("Not enough money to build, need " + (buildCost - GameMaster.Money) + " more");
			// Spawn UI
			return false;
		}
		else
		{
			return true;
		}
	}
}
