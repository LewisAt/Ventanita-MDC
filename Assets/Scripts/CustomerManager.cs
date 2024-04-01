using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public GameObject[] Customers;
    public bool isTutorial = false;

    int randomCustomer;

    public void TriggerGameToRun()
    {
        GameManager.instance.isGameRunning = true;
    }
    void  Start()
    {
        
        GameManager.OnEndDay += disableAllCustomers;
        if(isTutorial)
        {
            GameManager.instance.isGameRunning = false;
            GameManager.instance.IsTutorialOn = true;
            return;
        }
        activateRandomCustomer();
    }
    /// <summary>
    /// Triggers the end game state if the current money saved exceeds the last money state.
    /// </summary>    
    public void activateRandomCustomer()
    {
        if(!GameManager.instance.isGameRunning)
        {
            return;
        }
        Debug.Log("Activating Random Customer");
        

        // the customers start all events for our game if we stop them we stop
        // steps 1-5


        randomCustomer = Random.Range(0, Customers.Length);
        if(Customers[randomCustomer].activeSelf)
        {
            activateRandomCustomer();
            return;
        }
        Customers[randomCustomer].SetActive(true);
        Debug.Log(Customers[randomCustomer].name + " is now active of Group " + Customers[randomCustomer].transform.parent.transform.parent.name);
    }

    public void resetCustomers(GameObject customer)
    {
        customer.SetActive(false);
    }
    void disableAllCustomers()
    {
        for (int i = 0; i < Customers.Length; i++)
        {
            Customers[i].SetActive(false);
        }
    }


}



// this is just a plan for what we need to make this work this manages the customers by reseting them when they reach a point.

//First we need a script to handle movement for the customers going from A To B then to C this needs to be seprate from the customer manager

//next we need a function that randimizes the order of the customer 

//then we need a function to reset the customers

//we also need to be able to handle at least 4 customers at a time.
/*
*/
