using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Determines if you get points if You get the order or not by TriggerEnter checking if colliders name is the same as name of the order

public class CustomerChecksOrderTest : MonoBehaviour
{
    
    
    typesOfFood CustomersOrder;

    void Start()
    {
        
        
        CustomersOrder = RandomMeal(CustomersOrder);
        Debug.Log(CustomersOrder);
    }

    //Randomizes but limits what an order can be
    public typesOfFood RandomMeal(typesOfFood order)
    {
        //*Add* multiple orders to experment 

        //0 = no meal
        int meal = 0; //Random.Range(0, 1);
        //1 = Croqueta and tostones combo *Example*
        if(meal == 0)
        {
            //*Add* Limitation function for Individual orders- while(!OrderIsValid)
            menuFood(order); 
        }
        if(meal == 1)
        {
            //*Add* Meal Options and a Random number will chose
            //menuMeal(order);
        }
        return order;
    }
    void menuFood(typesOfFood orderedItem)
    {
        bool OrderIsValid = false;
        int randRoll = 6;

        while (!OrderIsValid)
        {
            if (randRoll == 0)
                OrderIsValid = false;
            else if (randRoll == 1)
                OrderIsValid = true;
            else if (randRoll == 2)
                OrderIsValid = true;
            else if (randRoll == 3)
                OrderIsValid = true;
            else if (randRoll == 4)
                OrderIsValid = true;
            else if (randRoll == 5)
                OrderIsValid = true;
            else
            {
                randRoll = Random.Range(0, 5);
                
            }
                

        }
        //*Problem* Not Randomizing; defaulting to zero
        orderedItem = (typesOfFood)Random.Range(0, 5);
    }
    
    //void menuMeal(typesOfFood orderedItems)
    //{
    //    int randRoll = Random.Range(0, 3);
    //    orderedItems = (typesOfFood)randRoll;
    //    //if(orderedItems == 0)

    //}
    void OnTriggerEnter(Collider collider)
    {
        //Deletes Plate
        if (collider.gameObject.tag == "plate")
        {
            Destroy(collider.gameObject);
        }

        //Food will be checked separately because its not a child
        
        if (collider.gameObject.tag == "food")
        {
            foodIdentifier givenFood = collider.GetComponent<foodIdentifier>();
            //*Add* Implement a function that checks if given food matches CustomersOrder. The function will 
            if (givenFood.food == CustomersOrder)
            {
                Debug.Log("Thank You");
                Destroy(collider.gameObject);
            }
            else
            {
                Debug.Log("F*ck $^@*#!* !#&@^$");
                Destroy(collider.gameObject);
            }
        }
    }
}
