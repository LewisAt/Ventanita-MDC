using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeOrderInput : MonoBehaviour
{
    public CustomerOrder[] possibleOrders;
    CustomerOrder ActualOrder;

    void Start()
    {
        MakeAnOrder();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plate")
        {
            other.GetComponent<CustomerOrder>().StartFood();
            ConfirmOrder(other);
        }
        
    }
    void ConfirmOrder(Collider givenPlate)
    {
        int mealAccuracyCount = 0;
        if (givenPlate.gameObject.GetComponent<CustomerOrder>().getMealName() == ActualOrder.getMealName())
        {
            mealAccuracyCount++;
            
        }
        else
        {
            print("Meal Name is Wrong");
            print("Meal Name: " + givenPlate.gameObject.GetComponent<CustomerOrder>().getMealName());
            print("Correct Meal Name: " + ActualOrder.getMealName());
        }
            
        if (givenPlate.gameObject.GetComponent<CustomerOrder>().Mains == ActualOrder.Mains)
        {
            mealAccuracyCount++;
        }
        else
        {
            print("Main is incorrect");
            print("Main: " + givenPlate.gameObject.GetComponent<CustomerOrder>().Mains);
            print("Correct Main: " + ActualOrder.Mains);
        }

        if (givenPlate.gameObject.GetComponent<CustomerOrder>().sides == ActualOrder.sides)
        {
            if (givenPlate.gameObject.GetComponent<CustomerOrder>().getNumOfSides() == ActualOrder.getNumOfSides())
            {
                mealAccuracyCount++;
            }
            else
            {
                Debug.Log("Side Number 0 is incorrect");
                Debug.Log("Side: " + givenPlate.gameObject.GetComponent<CustomerOrder>().sides);
                Debug.Log("Correct Side: " + ActualOrder.sides);
            }
        }
        
        
        if (givenPlate.gameObject.GetComponent<CustomerOrder>().getCoffeeBool() == ActualOrder.getCoffeeBool())
        {
            mealAccuracyCount++;
        }
        else
            print("Coffee is incorrect");
        if (givenPlate.gameObject.GetComponent<CustomerOrder>().hasRice == ActualOrder.hasRice)
        {
            mealAccuracyCount++;
        }
        else
            print("Rice is incorrect");
        //Checks if meal is correct
        print(mealAccuracyCount + "out of 5");
        if(mealAccuracyCount == 5)
        {
            print("Correct");
            //Reward Player

        }
    }

    void MakeAnOrder()
    {
        int rand = Random.Range(0, possibleOrders.Length);
        ActualOrder = possibleOrders[rand];
        ActualOrder.randomizeFactors();
        ActualOrder.StartFood();
        Debug.Log(ActualOrder.getMealName());
        
        //Insert UI Change coding here

    }
    
}
