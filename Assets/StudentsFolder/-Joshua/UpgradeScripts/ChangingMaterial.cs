using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangingMaterial : MonoBehaviour
{
    //creates a list for the materials that will be used
    public Material[] material;
    // X is being used as the order of the materials in the list
    public int x;
    //Used to become the new material for the object it is set to and keeps the change when the scene is reloaded
    public static int newMaterial;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the x to 0, whichs sets the material of the object to 0
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
        OnAwake();
    }

    void OnAwake()
    {
        //Sets the x to the same value as the new material
        x = newMaterial;
        //newMaterial = x;

    }

    // Update is called once per frame
    void Update()
    {
        //sets the material in the list to the material that matches with the value of x
        rend.sharedMaterial = material[x];
        //newMaterial = x;
        //Updates the material of an object by setting it to the material that matches the current value of X
        newMaterial = x;
    }

    //Fuction to be attached to a button to that changes the material of an object when pressed
    public void NextMaterial()
    {
        //Checks the current value of x to see if it is less than 2, if it is less than 2 it will increase the value 0f x
        if (x < 2)
        {
            x++;
            //newMaterial = x;
        }
        //if the current value of x is greater than or eqaul to 2, this will set the current value of x to 0
        else
        {
            x = 0;
        }
    }
}
