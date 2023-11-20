using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryFIxScript : MonoBehaviour
{
    //SOMEONE FIX THE ISSUE
    //screw unity ontriggerenter sometimes

    // declare variables
    public float respawn_x;
    public float respawn_y;
    public float respawn_z;

    void Start()
    {
        // then declare the float values
        respawn_x = 12.249f;
        respawn_y = 0.277f;
        respawn_z = 6.926798f;
    }

    void OnTriggerEnter(Collider other)
    {
        //check if the player is out of bounds
        if (other.gameObject.tag == "BoundaryFix")
        {
            transform.position = new Vector3(respawn_x, respawn_y, respawn_z);
            Debug.Log("Out of bounds detected! Respawning player properly...");
        }
    }
}
