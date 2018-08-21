/*  File:       #SCRIPTNAME#
 *  Creator:    Sweet
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
 
using UnityEngine;

using System.Collections.Generic;

/// <summary>
/// handles the base behavior of all towers
/// </summary>
public class Structure : GameUnit
{
    [Header("Structure Properties")]
    // price for building the tower
    public int buildCost = 0;
    // price for upgrading the tower
    public int sellCost = 0;

	// public GameObject upgradedTowerPrefab;
	public List<GameObject> UpgradedStructuresPrefabs = new List<GameObject>();
    public Node node;
    
    /// <summary>
    /// Create a link between tower and node
    /// </summary>
    /// <param name="_node"></param>
    public void LinkNode(Node _node)
    {
        node = _node;
        node.towerOnThisNode = this;
	}

    /// <summary>
    /// Creates a death effect
    /// Destroy this object
    /// depopulate the node, so there can be built another tower
    /// changes node layer to Envirovment, so others can walk on it
    /// </summary>
    protected override void Die()
    {
        base.Die();
        node.populated = false;
        node.gameObject.layer = LayerMask.NameToLayer("Envirovment");
    }
}
