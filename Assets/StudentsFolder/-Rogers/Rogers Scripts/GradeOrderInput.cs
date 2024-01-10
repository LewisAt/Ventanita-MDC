using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

//This Script attached to the customer window when triggered by a customer sprite will store a randomized
//order from the customer order script and when triggered by a plate the customer will compare values to determine
//whether they match
public class GradeOrderInput : MonoBehaviour
{
    public CustomerOrder[] possibleOrders;
    public CustomerOrder ActualOrder;
    float moneyEarned;
    //public TMP_Text MoneyText;
    private int CustomerTimer = 30;
    public TMP_Text LevelTimerText;
    public int mealAccuracyCount = 0;

    private IEnumerator CustomerTimerCoroutine;
    public Slider CustomerSliderUI;
    public AudioSource incorrectOrderSound;

    void Start()
    {
        CustomerTimerCoroutine = SubtrackSeconds();
    }

    private Movetowindow customer;
    public void addCustomer(Movetowindow NewCustomer)
    {
        if(Movetowindow.sameId == 0)
        {
            customer = NewCustomer;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //this starts grading when colliding with a plate

        if (other.tag == "plate")
        {
            other.GetComponent<plateIdentifier>();
            ConfirmOrder(other);
        }

    }
    private void Update()
    {
        
        if(CustomerTimer <= 0)
        {
            StopCoroutine(CustomerTimerCoroutine);
        }
    }
   
    IEnumerator SubtrackSeconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            CustomerTimer -= 1;
            CustomerSliderUI.value = CustomerTimer;

            if (CustomerTimer <= 0)
            {
                if(Movetowindow.sameId == 1)
                {
                    customer.CompleteCustomerTimeRanOut();
                    resetIcons();
                    Debug.Log("this works");
                }
                else if(Movetowindow.sameId == 2)
                {
                    customer.CompleteCustomerTimeRanOut2();
                    resetIcons();
                }
            }
        }
    }
    void ConfirmOrder(Collider givenPlate) //Grades the plate by comparing enums Main and Side, Side nums, Rice bool, and coffee(Not Yet Implemented)
    {
        mealAccuracyCount = 0;

        if (givenPlate.gameObject.GetComponent<plateIdentifier>().plateMain == ActualOrder.Mains)
        {
            mealAccuracyCount++;
        }
        else
        {
            FoodNameHeader.text = "Main is incorrect";
        }

        //checSides 1 
        //Compares Side 1 Enum in players given plate with customers order and changes customer text to explain why incorrect
        if (givenPlate.gameObject.GetComponent<plateIdentifier>().plateSide == ActualOrder.sides)
        {
            if (givenPlate.gameObject.GetComponent<plateIdentifier>().SideCount == ActualOrder.getNumOfSides())
            {
                mealAccuracyCount++;
            }
            else if (givenPlate.gameObject.GetComponent<plateIdentifier>().SideCount > ActualOrder.getNumOfSides())
            {
                FoodNameHeader.text = "Too much of the 1st side was given!";
            }
            else if (givenPlate.GetComponent<plateIdentifier>().SideCount < ActualOrder.getNumOfSides() && ActualOrder.getNumOfSides() != 0)
            {
                FoodNameHeader.text = "Too little of the 1st side was given";
            }
            else
            {
                FoodNameHeader.text = "1st Side portion is wrong";
            }
        }
        else
        {
            FoodNameHeader.text = "Side is incorrect";
        }

        //2nd Sides coding
        //Compares Side 2 Enum in players given plate with customers order and changes customer text to explain why incorrect
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
            }
        }
        else
        {
            FoodNameHeader.text = "2nd Side is incorrect";
        }
        //Coffee not yet implemented
        /*
        if (givenPlate.gameObject.GetComponent<plateIdentifier>().hasCoffee == ActualOrder.getCoffeeBool())
        {
            mealAccuracyCount++;
        }
        else
           print("Coffee is incorrect");
        */

        //Compare Rice bool and changes customer text to explain why incorrect
        if (givenPlate.gameObject.GetComponent<plateIdentifier>().hasRice == ActualOrder.hasRice)
        {
            mealAccuracyCount++;
        }
        else
            FoodNameHeader.text = "Rice is incorrect";
        //Checks if meal is correct
        print(mealAccuracyCount + " out of 4");
        if (mealAccuracyCount == 4) //Verifies if the customer is correct or not by int comparison added above
        {
            StopCoroutine(CustomerTimerCoroutine);
            if(Movetowindow.sameId == 1)
            {
                customer.CompleteCustomerCorrect();
            }
            if (Movetowindow.sameId == 2)
            {
                customer.CompleteCustomerCorrect2();
            }
            //moneyEarned += ActualOrder.foodsCost;
            //MoneyText.text = "Money Earned\n$" + moneyEarned.ToString();
            //CustomerTimer = 30;
            FoodNameHeader.text = "Correct";
            Destroy(givenPlate.gameObject);
            //Reward Player

        }
        else
        {
            incorrectOrderSound.Play();
            StartCoroutine("youFailed");
        }
    }

    IEnumerator youFailed()
    {
        yield return new WaitForSeconds(3);
        FoodNameHeader.text = ActualOrder.ConfirmedMealName;
    }

    public void MakeAnOrder() //Creates new order when called by TriggerMeal after being triggered by customer
    {
        resetIcons();
        int rand = Random.Range(0, possibleOrders.Length);
        ActualOrder = possibleOrders[rand];
        ActualOrder.randomizeFactors();
        ActualOrder.StartFood();

        CustomerTimer = 30;
        assignIcon(ActualOrder);
        StartCoroutine(CustomerTimerCoroutine);

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
    public Text RiceText;
    public Text MainText;
    public Text Side1Text;
    public Text Side2Text;

    void resetIcons()
    {
        RiceIcon.sprite = null;
        MainImageIcon.sprite = null;
        SideImageIcon.sprite = null;
    }
    public void assignIcon(CustomerOrder CurrentlySelectedOrder)
    {
        // this bit displays if there is rice else we display nothing
        //Currently he have no Icon for nothing so we  display a white image
        if (CurrentlySelectedOrder.hasRice)
        {
            RiceIcon.sprite = RiceSprite;
        }
        //Coffee not yet implemented
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
                //Debug.Log((int)CurrentlySelectedOrder.Mains);
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
        RiceText.text = ActualOrder.rice;
        MainText.text = ActualOrder.main;
        Side1Text.text = ActualOrder.side1;
        Side2Text.text = ActualOrder.side2;

    }

}
    
