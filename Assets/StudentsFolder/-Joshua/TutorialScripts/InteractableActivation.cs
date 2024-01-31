using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Pooling;
using UnityEngine.InputSystem;

public class InteractableActivation : MonoBehaviour
{
    public GameObject Ladle;
    public GameObject Plate;
    public XRGrabInteractable XRGrabInteractable;
    public PlateSpawn plateSpawn;
    // Start is called before the first frame update
    void Start()
    {
        if (Ladle.name == "ladle")
        {
            XRGrabInteractable.GetComponent<XRGrabInteractable>().enabled = false;
        }

        ActivatePlate();
    }

    public void ActivateLadle()
    {
        if (Ladle.name == "ladle")
        {
            XRGrabInteractable.GetComponent<XRGrabInteractable>().enabled = true;
        }
    }

    public void ActivatePlate()
    {
        //plateSpawn.GetComponent<PlateSpawn>().enabled = true;
        plateSpawn = Plate.GetComponent<PlateSpawn>();
        plateSpawn.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
