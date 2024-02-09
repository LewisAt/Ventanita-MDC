using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRemoval : MonoBehaviour
{
    PlateServing plateServe;

    /*This script functions to swipe the plate once it is inserted in the sink*/
    private void Start()
    {
        plateServe = GetComponentInParent<PlateServing>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "sink")
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.childCount == 0) { return; }
                Destroy(transform.GetChild(i).gameObject);
                plateServe.Swipe();
            }
        }
    }

    private void Update()
    {
        print(gameObject.name + " has " + transform.childCount + " children");
    }
}
       
