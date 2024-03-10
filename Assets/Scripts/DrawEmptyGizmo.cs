using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawEmptyGizmo : MonoBehaviour
{
    
    public Color gizmoColor = Color.white;
    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor ;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
