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
    [HideInInspector]
    public CustomerOrder[] possibleOrders;
    public CustomerOrder ActualOrder;
    public float moneyEarned;
    //public TMP_Text MoneyText;
    DifficultyDirector difficultyDirector;
    bool Correct = false;
    private int CustomerTimer = 30;
    public TMP_Text LevelTimerText;
    public int mealAccuracyCount = 0;
    bool isBeingChecked = false;
    private IEnumerator CustomerTimerCoroutine;
    public Slider CustomerSliderUI;
    public AudioSource incorrectOrderSound;
    private void OnEnable()
    {
        CustomerTimerCoroutine = SubtrackSeconds();
        difficultyDirector = GameObject.FindGameObjectWithTag("DifficultyDirector").GetComponent<DifficultyDirector>();
        difficultyDirector.getDifficulty();
    }
    private Movetowindow customer;
    public void addCustomer(Movetowindow NewCustomer)
    {
        if (Movetowindow.sameId == 0)
        {
            customer = NewCustomer;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //this starts grading when colliding with a plate

        if (other.CompareTag("plate"))
        {
            plateIdentifier givenPlateID = other.gameObject.GetComponent<plateIdentifier>();
            ConfirmOrder(givenPlateID);
        }
    }
    private void Update()
    {

        if (CustomerTimer <= 0)
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
                if (Movetowindow.sameId == 1)
                {
                    customer.CompleteCustomerTimeRanOut();
                    resetIcons();
                }
            }
        }
    }

    void ConfirmOrder(plateIdentifier givenPlate) //Grades the plate by comparing enums Main and Side, Side nums, Rice bool, and coffee(Not Yet Implemented)
    {
        if (givenPlate.plateMain == ActualOrder.Mains
            && givenPlate.plateSide == ActualOrder.sides
            && givenPlate.plateSide1 == ActualOrder.sides1
            && givenPlate.hasRice == ActualOrder.hasRice)
        {
            ActualOrder = null;
            resetIcons();
            StopCoroutine(CustomerTimerCoroutine);
            /* Causes Customer to freeze
            if (Movetowindow.sameId == 2)
            {
                customer.CompleteCustomerCorrect();
            }
            */
            customer.CompleteCustomerCorrect();

            //moneyEarned += ActualOrder.foodsCost;
            //MoneyText.text = "Money Earned\n$" + moneyEarned.ToString();
            //CustomerTimer = 30;
            FoodNameHeader.text = "Correct";

        }
        else
        {
            incorrectOrderSound.Play();
            StartCoroutine("youFailed");
        }
        Destroy(givenPlate.gameObject);
        givenPlate = null;
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
        RiceText.text = null;
        MainText.text = null;
        Side1Text.text = null;
        Side2Text.text = null;
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