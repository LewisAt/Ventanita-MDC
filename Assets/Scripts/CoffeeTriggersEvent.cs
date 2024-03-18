using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeTriggersEvent : MonoBehaviour
{
    public delegate void CoffeeTrigger();
    public static event CoffeeTrigger OnCoffeeTrigger;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            OnCoffeeTrigger();
        }
    }
}
