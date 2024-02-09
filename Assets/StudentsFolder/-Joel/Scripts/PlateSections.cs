using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSections : MonoBehaviour
{

    //identifier enum for the plate.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "plate")
        {
            collision.transform.SetParent(transform);
        }
    }
}
