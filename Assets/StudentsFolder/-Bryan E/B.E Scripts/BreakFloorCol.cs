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
    }
}
