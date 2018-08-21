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
    private Material startColor;
    public Material hoverColor;
    public Material poweredColor;
    
    // Unity setup
    [HideInInspector]
    public bool populated = false;
    public bool minable = false;
    public bool isPowered = false;

    [HideInInspector]
    public Structure towerOnThisNode;
    public TowerShop towerShop;

    // offset position for building towers
    public Vector3 positionOffset;

    /// <summary>
    /// Gets the renderer component and sets starting color, to which it will return when not highlighted
    /// </summary>
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material;
    }

    void Update()
    {
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

        towerShop.SelectNode(this);
    }

    /// <summary>
    /// Changes the color on enter
    /// </summary>
    void OnMouseEnter()
    {
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
        rend.material = startColor;
    }    

    /// <summary>
    /// offsets the building of turret a little so it's not in the envirovment
    /// </summary>
    /// <returns></returns>
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }    
}
