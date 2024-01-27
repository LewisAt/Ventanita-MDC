using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakFloorCol : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "plate")
        {
            Debug.Log("Hello floor");
            StartCoroutine(other.gameObject.GetComponent<PlateBreak>().startBreak());
        }
    }
}
