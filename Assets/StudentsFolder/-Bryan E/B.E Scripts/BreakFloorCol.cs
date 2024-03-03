using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakFloorCol : MonoBehaviour
{
    public AudioSource breaksound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "plate")
        {
            Debug.Log("Hello floor");
            breaksound.Play();
            StartCoroutine(other.gameObject.GetComponent<PlateBreak>().startBreak());
        }
        //Joel is adding the ladle to this script so the ladle breaks when it hits the floor
        else if (other.gameObject.tag == "spoon")
        {
            NewPoolingMethod tempScript = other.GetComponent<NewPoolingMethod>();
            breaksound.Play();
            StartCoroutine(other.gameObject.GetComponent<LaldleIdentifier>().Respawn());

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
