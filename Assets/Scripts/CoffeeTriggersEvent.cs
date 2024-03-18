using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeTriggersEvent : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coffee")
        {
            Debug.Log("Coffee Triggered");
            GameManager.instance.loadNextDay();
        }
    }
}
