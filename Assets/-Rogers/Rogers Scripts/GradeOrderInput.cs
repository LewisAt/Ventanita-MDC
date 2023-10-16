using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradeOrderInput : MonoBehaviour
{
    public CustomerOrder[] possibleOrders;
    CustomerOrder ActualOrder;

    void Start()
    {
        MakeAnOrder();
        Debug.Log(ActualOrder.hasRice);
        Debug.Log(ActualOrder.Mains);
        Debug.Log(ActualOrder.sides);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "plate")
        {
            Debug.Log(other.gameObject.name + "We git a plate");
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

        /*if (givenPlate.gameObject.GetComponent<plateIdentifier>().hasCoffee == ActualOrder.getCoffeeBool())
        {
            mealAccuracyCount++;
        }
        else
            print("Coffee is incorrect");
        */
        if (givenPlate.gameObject.GetComponent<plateIdentifier>().hasRice == ActualOrder.hasRice)
        {
            mealAccuracyCount++;
        }
        else
            print("Rice is incorrect");
        //Checks if meal is correct
        
        Debug.Log(mealAccuracyCount);
        if (mealAccuracyCount == 3)
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
        assignIcon(ActualOrder);

        //Insert UI Change coding here

    }


    //This Whole Section Is dedicated to displaying The UI of the Food.

    public Image RiceIcon;
    public Sprite RiceSprite;
    public Sprite[] MainIconSpriteInOrderOfEnum;
    public Image MainImageIcon;

    public Sprite[] SideIconSpriteInOrderOfEnum;
    public Image SideImageIcon;

    public Text FoodNameHeader;
    public Text FoodCostText;
    public void assignIcon(CustomerOrder CurrentlySelectedOrder)
    {
        // this bit displays if there is rice else we display nothing
        //Currently he have no Icon for nothing so we  display a white image
        if(CurrentlySelectedOrder.hasRice)
        {
            RiceIcon.sprite = RiceSprite;
        }
        if(!CurrentlySelectedOrder.hasRice)
        {
            SideImageIcon = MainImageIcon;
            MainImageIcon = RiceIcon;
        }
        if((int)CurrentlySelectedOrder.Mains == 0)
        {
            SideImageIcon = RiceIcon;
        }

        for(int i = 1; i < 4; i++)
        {
            if((int)CurrentlySelectedOrder.Mains == i)
            {
                MainImageIcon.sprite = MainIconSpriteInOrderOfEnum[i];
            }
        }
   
        for (int i = 1; i < 4; i++)
        {
            if ((int)CurrentlySelectedOrder.sides == i)
            {
                SideImageIcon.sprite = SideIconSpriteInOrderOfEnum[i];
            }
        }

        FoodNameHeader.text = CurrentlySelectedOrder.ConfirmedMealName;
        FoodCostText.text = "$" + CurrentlySelectedOrder.foodsCost.ToString();

    }
    
}
