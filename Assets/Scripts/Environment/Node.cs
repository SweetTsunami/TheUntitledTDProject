/*  File:       #SCRIPTNAME#
 *  Creator:    Sweet
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
 
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;

/// <summary>
/// sets up the behavior of all nodes
/// </summary>
public class Node : MonoBehaviour
{// I changed this
    // Color Setup
    private Renderer rend;
	private MeshRenderer meshRenderer;
    private Material startColor;
    public Material hoverColor;
    public Material poweredColor;
    
    // Unity setup
    [HideInInspector]
    public bool populated = false;
    public bool minable = false;
    public bool isPowered = false;

    [HideInInspector]
    public Structure structureOnThisNode;

    // offset position for building towers
    public Transform positionOffset;

    /// <summary>
    /// Gets the renderer component and sets starting color, to which it will return when not highlighted
    /// </summary>
    private void Start()
    {
        rend = GetComponent<Renderer>();
		meshRenderer = GetComponent<MeshRenderer>();
		meshRenderer.enabled = false;
		startColor = rend.material;
    }
	
    /// <summary>
    /// Moves and chooses the correct UI to build or upgrade towers
    /// </summary>
    void OnMouseDown()
    {
        // don't build if the UI is over node
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
		if (UIManager_battle.SelectedNode == this)
		{
			UIManager_battle.SelectedNode = null;
		}
		else
		{
			UIManager_battle.SelectedNode = this;
		}
    }

    /// <summary>
    /// Changes the color on enter
    /// </summary>
    void OnMouseEnter()
    {
		meshRenderer.enabled = true;
		if (isPowered)
		{
			rend.material = poweredColor;
		}
		else
		{
			rend.material = hoverColor;
		}
    }

    /// <summary>
    /// Changes the color on exit
    /// </summary>
    void OnMouseExit()
    {
		meshRenderer.enabled = false;
        rend.material = startColor;
    }    

    /// <summary>
    /// offsets the building of turret a little so it's not in the envirovment
    /// </summary>
    /// <returns></returns>
    public Transform GetBuildPosition()
    {
        return gameObject.transform/* + positionOffset*/;
    }    
}
