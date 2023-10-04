using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodCombinatations : MonoBehaviour
{
    //MealObject customerOrder;

    bool wantsSide;
    bool wantsRice;
    int debt = 0;

    
    public CustomerOrder[] possibleOrders;
    CustomerOrder ActualOrder;

     
    //what customer is going to hold when observing plate

    void Awake()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        //col.transform.SetParent(this.transform);
        //CustomerOrder accepts arrays

        //Checks Main
        /*
        if (ActualOrder.Mains == col.gameObject.GetComponent<CustomerOrder>().Mains)
        {
            print("Correct");
        }
        else
        {
            print(ActualOrder.Mains);
            print(col.gameObject.GetComponent<CustomerOrder>().Mains);
        }




        if (ActualOrder.sides == col.gameObject.GetComponent<CustomerOrder>().sides)
        {
            print("Correct");
        }
        else
        {
            print(ActualOrder.sides);
            print(col.gameObject.GetComponent<CustomerOrder>().sides);
        }
        if (ActualOrder.hasCoffee == col.gameObject.GetComponent<CustomerOrder>().hasCoffee) 
        {
            print("Correct");
        }
        else
        {
            print(ActualOrder.hasCoffee);
            print(col.gameObject.GetComponent<CustomerOrder>().hasCoffee);
        }        
        */


    }

    //Customer Makes Order out of select manually made orders

}
