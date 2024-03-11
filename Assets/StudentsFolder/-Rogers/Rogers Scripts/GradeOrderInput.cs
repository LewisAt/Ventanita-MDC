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

    private MoneyTracker moneyTracker;
    private int CustomerTimer = 30;
    public TMP_Text LevelTimerText;
    public int mealAccuracyCount = 0;
    private IEnumerator CustomerTimerCoroutine;
    public Slider CustomerSliderUI;
    public AudioSource incorrectOrderSound;
    public AudioSource completeSound;
    public AudioSource failSound;
    private TriggerMeal triggerMeal;//actual variable hold the the current customer
    public TriggerMeal MealTrigger
    {
        get { return triggerMeal; }
        set { triggerMeal = value; }
    }
    private void OnEnable()
    {
        PopulateDependencies();
    }
    private void PopulateDependencies()
    {
        // populates the dependencies for the script
        difficultyDirector = GameObject.FindGameObjectWithTag("DifficultyDirector").GetComponent<DifficultyDirector>();
        
        moneyTracker = this.GetComponent<MoneyTracker>();
        triggerMeal = GameObject.Find("====GameSystems====/CustomerWindowTrigger").GetComponent<TriggerMeal>();
        //starts the timer for the customer and sets the difficulty
        CustomerTimerCoroutine = SubtrackSeconds();
        difficultyDirector.getDifficulty();


        Debug.Log("Populated Dependencies");
        debugCheckDependencies();
    }
    private void debugCheckDependencies()
    {
        if (difficultyDirector == null)
        {
            Debug.Log("Difficulty Director is null");
        }
        else
        {
            Debug.Log("Difficulty Director is not null");
        }
        if (moneyTracker == null)
        {
            Debug.Log("Money Tracker is null");
        }
        else
        {
            Debug.Log("Money Tracker is not null");
        }
        if (triggerMeal == null)
        {
            Debug.Log("Trigger Meal is null");
        }
        else
        {
            Debug.Log("Trigger Meal is not null");
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

        //! this input is for debugg remove later
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CompleteCustomerCorrect();
            ActualOrder = null;
            resetIcons();
            StopCoroutine(CustomerTimerCoroutine);
            FoodNameHeader.text = "Correct";
        }
    }

    IEnumerator SubtrackSeconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            CustomerTimer -= 1;
            CustomerSliderUI.value = CustomerTimer;
            if(CustomerTimer <= 0)
            {
                CustomerFailed();
                resetIcons();
            }
        }
    }
    void CustomerFailed()
    {
        CompleteCustomerTimeRanOut();
        triggerMeal.UnpauseCustomer();
        resetIcons();
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

            CompleteCustomerCorrect();

            FoodNameHeader.text = "Correct";

        }
        else//plays inncorect sound when wrong.
        {
            incorrectOrderSound.Play();
            StartCoroutine("youFailed");
        }
        Destroy(givenPlate.gameObject);
        givenPlate = null;
    }


     public void CompleteCustomerCorrect()
    {
        completeSound.Play();
        //this is a great...
        Debug.Log(ActualOrder);
        moneyTracker.UserCash += ActualOrder.foodsCostForCustomer ;
        CustomerSliderUI.value = 30;
        triggerMeal.UnpauseCustomer();
        resetIcons();
    }
    public void CompleteCustomerTimeRanOut()
    {
        failSound.Play();

    }

    IEnumerator youFailed()
    {
        yield return new WaitForSeconds(3);
        FoodNameHeader.text = ActualOrder.ConfirmedMealName;
    }

    public void MakeAnOrder() //Creates new order when called by TriggerMeal after being triggered by customer
    {
        Debug.Log("Making an order");
        resetIcons();
        int rand = Random.Range(0, possibleOrders.Length);
        ActualOrder = possibleOrders[rand];
        ActualOrder.randomizeFactors();
        if(ActualOrder == null)
        {
            Debug.Log("Actual Order is null");
        }
        else
        {
            Debug.Log("Actual Order is not null");
        }   
        ActualOrder.StartFood();

        CustomerTimer = 30;
        assignIcon(ActualOrder);
        StartCoroutine(CustomerTimerCoroutine);

        //Insert UI Change coding here

    }



    /// <summary>
    // this bit is for the UI to display the order on the customer window
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