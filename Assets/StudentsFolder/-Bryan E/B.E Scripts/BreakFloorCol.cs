using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakFloorCol : MonoBehaviour
{
    public AudioSource breaksound;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<HeldProtectionRule>())
        {
            if(other.GetComponent<HeldProtectionRule>().IsBeingHeld)
            {
                return;
            }
        }
   
        Debug.Log("Somn hit the floor");
        if (other.gameObject.tag == "plate")
        {
            Debug.Log("Hello floor");
            breaksound.Play();
            StartCoroutine(other.gameObject.GetComponent<PlateBreak>().startBreak());
        }
        //Joel is adding the ladle to this script so the ladle breaks when it hits the floor
        if (other.gameObject.tag == "spoon")
        {
        if(other.transform.parent.GetComponent<HeldProtectionRule>()) 
        {
            if(other.transform.parent.GetComponent<HeldProtectionRule>().IsBeingHeld)
            {
                return;
            }
        }
            Debug.Log("Hello spoon");
            NewPoolingMethod tempScript = other.GetComponent<NewPoolingMethod>();
            breaksound.Play();
            StartCoroutine(other.gameObject.GetComponent<LaldleIdentifier>().Respawn());

        }
        if(other.gameObject.tag == "Coffee")
        {
            Debug.Log("Hello coffee");
            breaksound.Play();
            StartCoroutine(other.gameObject.GetComponent<CoffeeReset>().ResetCoffee());
        }
    }
}
