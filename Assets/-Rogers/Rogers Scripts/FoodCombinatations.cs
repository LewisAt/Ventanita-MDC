using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodCombinatations : MonoBehaviour
{
    //MealObject customerOrder;

    bool wantsSide;
    bool wantsRice;
    MealObject CustomersOrder;
    //public CustomersOrder[] possibleOrders;
    
    //what customer is going to hold when observing plate

    void Awake()
    {
        randomMeal();
    }
    void OnTriggerEnter(Collider col)
    {
        //col.transform.SetParent(this.transform);
        if (CustomersOrder.Mains == col.gameObject.GetComponent<PlateContents>().Mains)
        {
            print("Correct");
        }
        else
        {
            print(CustomersOrder.Mains);
            print(col.gameObject.GetComponent<PlateContents>().Mains);
        }
        
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
        int randRoll = 0;
        //int randRoll = Random.Range(0, 3);
        //2 sets for now
        //mainFood rabo SideFood maduro
        if (randRoll == 0)
        {
            //CustomersOrder = possibleOrders[0];
        }

    }
}
