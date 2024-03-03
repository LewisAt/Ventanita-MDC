using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSpoon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "spoon")
        {
            NewPoolingMethod tempScript = other.GetComponent<NewPoolingMethod>();

            foreach (foodIdentifier f in tempScript.foodLadle)
            {
                if (f.GetComponent<MeshRenderer>().enabled == true)
                {
                    f.GetComponent<MeshRenderer>().enabled = false;
                    if (f.GetComponentInChildren<MeshRenderer>() != null)
                    {
                        MeshRenderer[] temp;
                        temp = f.GetComponentsInChildren<MeshRenderer>();
                        foreach (MeshRenderer r in temp) { r.enabled = false; }
                    }
                }
            }

            tempScript.isLadleFull = false;
        }
    }
}
