
using UnityEngine;

[CreateAssetMenu(fileName = "New StructureBlueprint", menuName = "StructureBlueprint")]
public class StructureBlueprint : ScriptableObject
{
	public new string name;
	public string description;
	public int buildCost;

	public Sprite icon;

	public GameObject prefab;
}
