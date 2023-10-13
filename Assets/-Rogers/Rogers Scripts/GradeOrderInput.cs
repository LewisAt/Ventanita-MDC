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

        //checSides 1 

        if (givenPlate.gameObject.GetComponent<plateIdentifier>().plateSide == ActualOrder.sides)
        {
            if (givenPlate.gameObject.GetComponent<plateIdentifier>().SideCount == ActualOrder.getNumOfSides())
            {
                mealAccuracyCount++;
            }
            else if(givenPlate.gameObject.GetComponent<plateIdentifier>().SideCount > ActualOrder.getNumOfSides())
            {
                print("Too much of the 1st side was given!");
            }
            else if(givenPlate.GetComponent<plateIdentifier>().SideCount < ActualOrder.getNumOfSides() && ActualOrder.getNumOfSides() != 0)
            {
                print("Too little of the 1st side was given");
            }
            else
            {
                print("1st Side portion is wrong");
                Debug.Log("1st Side: " + givenPlate.gameObject.GetComponent<plateIdentifier>().SideCount);
                Debug.Log("Correct 1st Side: " + ActualOrder.getNumOfSides());
            }
        }
        else
        {
            Debug.Log("Side is incorrect");
            Debug.Log("Side: " + givenPlate.gameObject.GetComponent<plateIdentifier>().plateSide);
            Debug.Log("Correct Side: " + ActualOrder.sides);
        }

        //2nd Sides coding

        if (givenPlate.gameObject.GetComponent<plateIdentifier>().plateSide1 == ActualOrder.sides1)
        {
            if (givenPlate.gameObject.GetComponent<plateIdentifier>().SideCount1 == ActualOrder.getNumOfSides1())
            {
                mealAccuracyCount++;
            }
            else if (givenPlate.gameObject.GetComponent<plateIdentifier>().SideCount1 > ActualOrder.getNumOfSides1())
            {
                print("Too much of the 2nd side was given!");
            }
            else if (givenPlate.GetComponent<plateIdentifier>().SideCount1 < ActualOrder.getNumOfSides1() && ActualOrder.getNumOfSides1() != 0)
            {
                print("Too little of the 2nd side was given");
            }
            else
            {
                print("2nd Side portion is wrong");
                Debug.Log("2nd Side: " + givenPlate.gameObject.GetComponent<plateIdentifier>().SideCount1);
                Debug.Log("Correct 2nd Side: " + ActualOrder.getNumOfSides1());
            }
        }
        else
        {
            Debug.Log("2nd Side is incorrect");
            Debug.Log("2nd Side: " + givenPlate.gameObject.GetComponent<plateIdentifier>().plateSide1);
            Debug.Log("Correct 2nd Side: " + ActualOrder.sides1);
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
        print(mealAccuracyCount + " out of 5");
        if(mealAccuracyCount == 5)
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
