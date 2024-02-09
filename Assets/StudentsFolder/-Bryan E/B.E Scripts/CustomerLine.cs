using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLine : MonoBehaviour
{
    public bool spot1 = false;
    public bool spot2 = false;
    public bool spot3 = false;
    public bool spot4 = false;

    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.name == "Spot 1")
        {
            spot1 = true;
        }
        else if (this.gameObject.name == "Spot 2")
        {
            spot2 = true;
        }
        else if (this.gameObject.name == "Spot 3")
        {
            spot3 = true;
        }
        else if (this.gameObject.name == "Spot 4")
        {
            spot4 = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (this.gameObject.name == "Spot 1")
        {
            spot1 = false;
        }
        else if (this.gameObject.name == "Spot 2")
        {
            spot2 = false;
        }
        else if (this.gameObject.name == "Spot 3")
        {
            spot3 = false;
        }
        else if (this.gameObject.name == "Spot 4")
        {
            spot4 = false;
        }
    }
}
