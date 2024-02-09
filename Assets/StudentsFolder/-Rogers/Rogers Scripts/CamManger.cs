using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManger : MonoBehaviour
{
    public Camera StoveCam;
    public Camera PotCam;
    // Start is called before the first frame update
    void Start()
    {
        StoveCam.enabled = true;
        PotCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)) 
        {
            StoveCam.enabled = !StoveCam.enabled;
            PotCam.enabled = !PotCam.enabled;
        }
    }
}
