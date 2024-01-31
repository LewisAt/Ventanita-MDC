using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReleaseDistance : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        if(Vector3.Distance(player.position,transform.position) > 0.4)
        {
            
        }
    }
}
