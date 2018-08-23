using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureBuilder : MonoBehaviour
{
	public void BuildStructure(StructureBlueprint structureBlueprint, Node _buildingNode)
	{
		GameObject builtStructure = Instantiate(structureBlueprint.prefab, _buildingNode.GetBuildPosition().position, Quaternion.identity);
		builtStructure.GetComponent<Structure>().LinkNode(_buildingNode);
		UIManager_battle.SelectedNode.gameObject.layer = LayerMask.NameToLayer("Obstacles");
	}

	public void UpgradeStructure(StructureBlueprint _structureBlueprint, Node _buildingNode)
	{
		Destroy(_buildingNode.structureOnThisNode.gameObject);

		BuildStructure(_structureBlueprint, _buildingNode);
	}
	public void SellStructure(Node _buildingNode)
	{
		GameMaster.Money += _buildingNode.structureOnThisNode.sellCost;

		Destroy(_buildingNode.structureOnThisNode.gameObject);
	 	UIManager_battle.SelectedNode.gameObject.layer = LayerMask.NameToLayer("Envirovment");
	}
}
