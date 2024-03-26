using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
====================================================================================================
                                        CLEAR SPOON SCRIPT
====================================================================================================
This script is attached to the CLEAROBJECT in the game.
It handles the clearing of the spoon when it hits THE SINK.
!it finds the players spoon via naming PLEASE MAKE SURE THE SPOON IS NAMED CORRECTLY and its parents
====================================================================================================
*/

public class ClearSpoon : MonoBehaviour
{
    [Header("Attach the spoon child of the ladle")]
    public NewPoolingMethod SpoonScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "spoon")
        {
            Debug.Log("Spoon is in the sink");
            SpoonScript.ClearCurrentFood();
        }
    }
}
