using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestforJoel : MonoBehaviour
{
    //Well the same can be done for scripts.
    public ItemGrabandSpawn OurScript;
    // here the public object is the name of the script we want and we can refrence in the same as the text in the inspector.
    
    public void Start()
    {
        // we can also access any public variables in the script we refrence with dot notation and the name of the variable we want to access.
        OurScript.isPlate = false;
        // in this i am changing the variable isPlate in anotehr script to false this also changes the state of that scipt
        // in the one you are refrencing.
    }
    
}
