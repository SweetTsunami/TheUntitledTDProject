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
public class PowerGeneratorModule : MonoBehaviour
{

    public float powerFieldRange = 5;
    List<Node> nodesInRange = new List<Node>();

    // Use this for initialization
    void Start()
    {
        FindNodesInRange();
    }

    void Update()
    {
        PowerUP();
    }

    /// <summary>
    /// draw the range of tower in red color
    /// </summary>
    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, powerFieldRange);
    }

    //protected override void Die()
    //{
    //    PowerDOWN();
    //    base.Die();
    //}

    private void PowerUP()
    {
        foreach (Node node in nodesInRange)
        {
            if (!node.isPowered)
                node.isPowered = true;
        }
    }

    private void PowerDOWN()
    {
        foreach (Node node in nodesInRange)
        {
                node.isPowered = false;
        }
    }

    private List<Node> FindNodesInRange()
    {
        Node[] nodes = FindObjectsOfType(typeof(Node)) as Node[];
        foreach (Node node in nodes)
        {
            if (Vector3.Distance(transform.position, node.transform.position) < powerFieldRange)
            {
                nodesInRange.Add(node);
            }
        }
        return nodesInRange;
    }
}
