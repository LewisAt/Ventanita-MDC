using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LadleToPlateProtectionRule : MonoBehaviour
{
    XRGrabInteractable grabInteractableOfPlateSpawner;
    private void Start() {
        grabInteractableOfPlateSpawner = GetComponent<XRGrabInteractable>();
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LadleBody")
        {
            Debug.Log("Ladle is out of the plate spawner");
            grabInteractableOfPlateSpawner.enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LadleBody")
        {
            Debug.Log("Ladle is insides the plate spawner");
            grabInteractableOfPlateSpawner.enabled = false;
        }
    }
}
