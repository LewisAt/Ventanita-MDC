using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate_Destroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "plate")
        {
            Destroy(collision.gameObject);
        }
    }
}
