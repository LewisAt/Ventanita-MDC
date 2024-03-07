using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSpoon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "spoon")
        {
            GameObject spoon = other.gameObject;

            Destroy(spoon.transform.GetChild(0).gameObject);

            other.gameObject.GetComponent<LaldleTrigger>().isLaldleFull = false;
        }
    }
}
