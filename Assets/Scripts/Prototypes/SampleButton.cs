/*  File:       SampleButton
 *  Creator:   Alexander Semenov
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour
{

	public Button buttonComponent;
	public Text nameLabel;
	public Image iconImage;
	public Text priceText;


	private StructureBlueprint structure;
	private StructureShop structureShop;

	// Use this for initialization
	void Start()
	{
		buttonComponent.onClick.AddListener(HandleClick);
	}

	public void Setup(StructureBlueprint currentGameUnit, StructureShop currentStructureShop)
	{
		structure = currentGameUnit;
		nameLabel.text = structure.name;
		iconImage.sprite = structure.icon;
		priceText.text = structure.buildCost.ToString();
		structureShop = currentStructureShop;

	}

	public void HandleClick()
	{
		structureShop.structureBuilder.BuildStructure(structure,UIManager_battle.SelectedNode);
	}
}
