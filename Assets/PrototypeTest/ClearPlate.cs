using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPlate : MonoBehaviour
{
    private PlateMaster plate;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plate")
        {
            plate = other.GetComponent<PlateMaster>();
            plate.ClearPlate();
        }
    }
}
