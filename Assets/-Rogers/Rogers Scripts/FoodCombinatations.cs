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

    //MealObject CustomersOrder;
    //Must be customerOrder
    public CustomerOrder[] possibleMainOrders;
    public CustomerOrder[] possibleSideOrders;
    CustomerOrder ActualOrder;

     
    //what customer is going to hold when observing plate

    void Awake()
    {
        randomMeal();
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
    bool rndBool
    {
        get { return (Random.value > 0.5f); }
    }
    //Randomizes if the customer wants a meal
    void randomWantsMeal()
    {
         wantsSide = rndBool;
        wantsRice = rndBool;
        if (wantsSide == true)
        {
            print("true");
            if(wantsRice == true)
            {
                
            }
            else
            {
                
            }
        }
        else
        {
            print("false");
        }
    }
    void randomMeal()
    {
        
        int randRoll = Random.Range(0, possibleMainOrders.Length);
        
        ActualOrder = possibleMainOrders[randRoll];
        randRoll = Random.Range(0, possibleSideOrders.Length);
        
        ActualOrder.sides = possibleSideOrders[randRoll].sides;
        bool wantCoffee = rndBool;
        
        
        




    }
}
