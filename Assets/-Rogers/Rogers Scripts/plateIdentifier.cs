using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateIdentifier : MonoBehaviour
{
    foodIdentifier plateContents;
    void OnCollisionEnter(Collision plate)
    {
        if (plate.gameObject.tag == "plate")
        {
            updateContents();
        }
    }
    void updateContents()
    {

    }
}
