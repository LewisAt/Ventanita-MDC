using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundInteractable : MonoBehaviour
{
    //MAKE THIS WORK FOR VR CONTROLS!!
    void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
    }
}
