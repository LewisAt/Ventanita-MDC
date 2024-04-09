using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEscapePrevention : MonoBehaviour
{
    private GameObject Player;
    private Vector3 RigLocation;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Was inside at start");
            Player = GameObject.FindGameObjectWithTag("Player");
            RigLocation = Player.transform.parent.transform.position;

        }
    
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player is trying to escape");
            RigLocation = Player.transform.parent.transform.position;
            Player.transform.position = RigLocation;
        }
    }
    void Update()
    {
        if (Player == null)
        {
            Debug.Log("playerWasOutsideOnstart");
            Player.transform.position = RigLocation;
        }
    }
    

}
