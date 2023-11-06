using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GradeOrderInput : MonoBehaviour
{
    public CustomerOrder[] possibleOrders;
    public CustomerOrder ActualOrder;
    float moneyEarned;
    public TMP_Text MoneyText;
    private int LevelTime = 180;
    private int CustomerTimer = 30;
    public TMP_Text LevelTimerText;

    public int mealAccuracyCount = 0;


    public Slider CustomerSliderUI;

    void Start()
    {
        StartCoroutine(SubtrackSeconds());
    }

    
    private void OnTriggerEnter(Collider other)
    {
        //starts order based on walk
        if (other.gameObject.name == "MakeOrderHitbox") 
        { 
            MakeAnOrder();
            
        }
        if (other.tag == "plate")
        {
            other.GetComponent<plateIdentifier>();
            ConfirmOrder(other);
        }
        
    }
    IEnumerator SubtrackSeconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (CustomerSliderUI.value <= 0)
            {
                CustomerTimer = 30;
            }
            CustomerTimer -= 1;
            CustomerSliderUI.value = CustomerTimer;
            
            LevelTime -= 1;
            timeformat();
        }

    }
    int seconds = 60;
    void timeformat()
    {
        
        int minutes = (int)LevelTime / 60;
        if(seconds <= 0)
        {
            seconds = 60;
        }
        seconds--;
        if(seconds < 10)
        {
            
            LevelTimerText.text = "Time Left \n" + minutes + ":" + "0" + seconds;
        }
        string timeText = "Time Left \n" + minutes + ":" + seconds;
        LevelTimerText.text = timeText;

    }
    void ConfirmOrder(Collider givenPlate)
    {
        mealAccuracyCount = 0;
            
        if (givenPlate.gameObject.GetComponent<plateIdentifier>().plateMain == ActualOrder.Mains)
        {
            mealAccuracyCount++;
        }
        else
        {
            FoodNameHeader.text = "Main is incorrect";
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
                FoodNameHeader.text = "Too much of the 1st side was given!";
            }
            else if(givenPlate.GetComponent<plateIdentifier>().SideCount < ActualOrder.getNumOfSides() && ActualOrder.getNumOfSides() != 0)
            {
                FoodNameHeader.text = "Too little of the 1st side was given";
            }
            else
            {
                FoodNameHeader.text = "1st Side portion is wrong";
                Debug.Log("1st Side: " + givenPlate.gameObject.GetComponent<plateIdentifier>().SideCount);
                Debug.Log("Correct 1st Side: " + ActualOrder.getNumOfSides());
            }
        }
        else
        {
            FoodNameHeader.text = "Side is incorrect";
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
                FoodNameHeader.text = "Too much of the 2nd side was given!";
            }
            else if (givenPlate.GetComponent<plateIdentifier>().SideCount1 < ActualOrder.getNumOfSides1() && ActualOrder.getNumOfSides1() != 0)
            {
                FoodNameHeader.text = "Too little of the 2nd side was given";
            }
            else
            {
                FoodNameHeader.text = "2nd Side portion is wrong";
                Debug.Log("2nd Side: " + givenPlate.gameObject.GetComponent<plateIdentifier>().SideCount1);
                Debug.Log("Correct 2nd Side: " + ActualOrder.getNumOfSides1());
            }
        }
        else
        {
            FoodNameHeader.text = "2nd Side is incorrect";
            Debug.Log("2nd Side: " + givenPlate.gameObject.GetComponent<plateIdentifier>().plateSide1);
            Debug.Log("Correct 2nd Side: " + ActualOrder.sides1);
        }
        /*
        if (givenPlate.gameObject.GetComponent<plateIdentifier>().hasCoffee == ActualOrder.getCoffeeBool())
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
            FoodNameHeader.text = "Rice is incorrect";
        //Checks if meal is correct
        print(mealAccuracyCount + " out of 4");
        if(mealAccuracyCount == 4)
        {
            moneyEarned += ActualOrder.foodsCost;
            //MoneyText.text = "Money Earned\n$" + moneyEarned.ToString();
            //CustomerTimer = 30;
            FoodNameHeader.text = "Correct";
            Destroy(givenPlate.gameObject);
            //Reward Player

        }
        else
        {
            StartCoroutine("youFailed");
        }
    }

    IEnumerator youFailed()
    {
        yield return new WaitForSeconds(3);
        FoodNameHeader.text = ActualOrder.ConfirmedMealName;
    }

    void MakeAnOrder()
    {
        int rand = Random.Range(0, possibleOrders.Length);
        ActualOrder = possibleOrders[rand];
        ActualOrder.randomizeFactors();
        ActualOrder.StartFood();
        Debug.Log(ActualOrder.getMealName());
        if (ActualOrder.sides != SideFoods.None)
        {
            print("Amount for the first Side: " + ActualOrder.getNumOfSides());
        }
        if (ActualOrder.sides1 != SideFoods.None)
        {
            print("Amout for the second side" + ActualOrder.getNumOfSides1());
        }
        assignIcon(ActualOrder);

        //Insert UI Change coding here

    }

    /// <summary>
    /// //////////////////////////////////////////
    /// </summary>
    public Image RiceIcon;
    public Sprite RiceSprite;
    public Sprite[] MainIconSpriteInOrderOfEnum;
    public Image MainImageIcon;

    public Sprite[] SideIconSpriteInOrderOfEnum;
    public Image SideImageIcon;

    /*
    public Image CoffeeIcon;
    public Sprite CoffeeSprite;
    */

    public Text FoodNameHeader;
    public Text FoodCostText;
    public void assignIcon(CustomerOrder CurrentlySelectedOrder)
    {
        // this bit displays if there is rice else we display nothing
        //Currently he have no Icon for nothing so we  display a white image
        if (CurrentlySelectedOrder.hasRice)
        {
            RiceIcon.sprite = RiceSprite;
        }

        /*
        if (CurrentlySelectedOrder.getCoffeeBool() == true)
        {
            CoffeeIcon.sprite = CoffeeSprite;
        }
        */
  
        for (int i = 1; i < 4; i++)
        {
            if ((int)CurrentlySelectedOrder.Mains == i)
            {
                Debug.Log((int)CurrentlySelectedOrder.Mains);
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
    
