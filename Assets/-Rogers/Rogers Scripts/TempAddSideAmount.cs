using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempAddSideAmount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddToSide();
            print("Side Added!");
        }
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
         //   this.GetComponent<CustomerOrder>().addCoffee();
           // print("Coffee Added!");
        //}
    }
    void AddToSide()
    {
        this.GetComponent<CustomerOrder>().addNumOfSides();
    }

}
