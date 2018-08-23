/*  File:       UIManager
 *  Creator:   Alexander Semenov
 *  Date:       
 *  Location:   Brno, Czech Republic
 *  Project:    
 *  Desc:       
 *  Usage:                  
 */
using UnityEngine;
 
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
	public GameObject selectedUI;

    public void DeselectUI()
    {
		if (selectedUI != null)
		{
			selectedUI.SetActive(false);
			selectedUI = null;
		}
    }

    public virtual void ToggleUI(GameObject targetUI)
    {
        if (selectedUI == null)
        {
            selectedUI = targetUI;
            selectedUI.SetActive(true);
        }
        else
        {
            DeselectUI();
            selectedUI = targetUI;
            selectedUI.SetActive(true);
        }
    }

	public void MoveUI(Transform target)
	{
		if (selectedUI)
		{
			selectedUI.transform.position = target.position;
		}
	}
}
