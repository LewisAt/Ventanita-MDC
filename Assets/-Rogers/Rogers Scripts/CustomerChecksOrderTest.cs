using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Determines if you get points if You get the order or not by TriggerEnter checking if colliders name is the same as name of the order

public class CustomerChecksOrderTest : MonoBehaviour
{

    int randRoll = 6;
    foodIdentifier.typesOfFood CustomersOrder;

    void Start()
    {

        //randomizes randRoll to randomize customerOrder
        RandomMeal();
        
    }

    //Randomizes but limits what an order can be
    public void RandomMeal()
    {
        //*Add* multiple orders to experment 

        //0 = no meal
        int meal = 0; //Random.Range(0, 1);
        //1 = Croqueta and tostones combo *Example*
        if(meal == 0)
        {
            //*Add* Limitation function for Individual orders- while(!OrderIsValid)
        }
        if(meal == 1)
        {
            //*Add* Meal Options and a Random number will chose
            //menuMeal();
        }
        
    }
    /*void menuFood()
    {
        bool OrderIsValid = false;
        

        while (!OrderIsValid)
        {
            if (randRoll == 0)
                OrderIsValid = true;
            else if (randRoll == 1)
                OrderIsValid = false;
            else if (randRoll == 2)
                OrderIsValid = false;
            else if (randRoll == 3)
                OrderIsValid = false;
            else if (randRoll == 4)
                OrderIsValid = true;
            else if (randRoll == 5)
                OrderIsValid = true;
            else
            {
                randRoll = Random.Range(0, 5);
                
            }
                

        }
        Debug.Log(randRoll);
        CustomersOrder = (foodIdentifier.typesOfFood)randRoll;
        Debug.Log(CustomersOrder);
    }*/

    void menuMeal()
    {
        randRoll = Random.Range(0, 3);
        if (randRoll == 0)
        {
            //combo rabo & beans
        }
        else if(randRoll == 1)
        {
            //combo rabo & fricase de pollo
        }

    }
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
