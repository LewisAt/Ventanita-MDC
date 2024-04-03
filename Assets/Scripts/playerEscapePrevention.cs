using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEscapePrevention : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player is trying to escape");
            other.gameObject.transform.position = this.transform.position;
        }
    }
}
