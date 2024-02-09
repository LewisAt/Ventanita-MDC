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
        if (other.tag == "plate")
        {
            other.GetComponent<plateIdentifier>();
            ConfirmOrder(other);
        }
        
    }
    void ConfirmOrder(Collider givenPlate)
    {
        int mealAccuracyCount = 0;
            
        if (givenPlate.gameObject.GetComponent<plateIdentifier>().plateMain == ActualOrder.Mains)
        {
            mealAccuracyCount++;
        }
        else
        {
            print("Main is incorrect");
            print("Main: " + givenPlate.gameObject.GetComponent<plateIdentifier>().plateMain);
            print("Correct Main: " + ActualOrder.Mains);
        }

        if (givenPlate.gameObject.GetComponent<plateIdentifier>().plateSide == ActualOrder.sides)
        {
            if (givenPlate.gameObject.GetComponent<plateIdentifier>().SideCount == ActualOrder.getNumOfSides())
            {
                mealAccuracyCount++;
            }
            else if(givenPlate.gameObject.GetComponent<plateIdentifier>().SideCount > ActualOrder.getNumOfSides())
            {
                print("Too much of the side was given!");
            }
            else if(givenPlate.GetComponent<plateIdentifier>().SideCount < ActualOrder.getNumOfSides() && ActualOrder.getNumOfSides() != 0)
            {
                print("Too little of the side was given");
            }
            else
            {
                print("Side portion is wrong");
                Debug.Log("Side: " + givenPlate.gameObject.GetComponent<plateIdentifier>().SideCount);
                Debug.Log("Correct Side: " + ActualOrder.getNumOfSides());
            }
        }
        else
        {
            Debug.Log("Side is incorrect");
            Debug.Log("Side: " + givenPlate.gameObject.GetComponent<plateIdentifier>().plateSide);
            Debug.Log("Correct Side: " + ActualOrder.sides);
        }

        if (givenPlate.gameObject.GetComponent<plateIdentifier>().hasCoffee == ActualOrder.getCoffeeBool())
        {
            mealAccuracyCount++;
        }
        else
            print("Coffee is incorrect");
        if (givenPlate.gameObject.GetComponent<plateIdentifier>().hasRice == ActualOrder.hasRice)
        {
            mealAccuracyCount++;
        }
        else
            print("Rice is incorrect");
        //Checks if meal is correct
        print(mealAccuracyCount + " out of 4");
        if(mealAccuracyCount == 4)
        {
            print("Correct");
            Destroy(givenPlate.gameObject);
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
