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
    public bool WindowResetDelay = false;
    public float moneyEarned;
    //public TMP_Text MoneyText;
    DifficultyDirector difficultyDirector;

    private MoneyTracker moneyTracker;
    private int CustomerTimer = 30;
    [SerializeField] private TMP_Text LevelTimerText;
    public int mealAccuracyCount = 0;
    private IEnumerator CustomerTimerCoroutine;
    [SerializeField] private Slider CustomerSliderUI;
    [SerializeField] private AudioSource incorrectOrderSound;
    [SerializeField] private AudioSource completeSound;
    [SerializeField] private AudioSource failSound;

    //!look at this later its causing and issue but IDK what it is
    private TriggerMealRequest triggerMeal;//actual variable hold the the current customer
    public TriggerMealRequest MealTrigger
    {
        get { return triggerMeal; }
        set { triggerMeal = value; }
    }
    private void  Start()

    {
        PopulateDependencies();
    }
    private void PopulateDependencies()
    {
        // populates the dependencies for the script
        difficultyDirector = GameObject.FindGameObjectWithTag("DifficultyDirector").GetComponent<DifficultyDirector>();
        
        moneyTracker = GameObject.Find("====GameSystems====/GameFunctions(POSITIONSMATTER)/MoneyTracker5").GetComponent<MoneyTracker>();
        triggerMeal = GameObject.Find("====GameSystems====/GameFunctions(POSITIONSMATTER)/CustomerWindowTrigger3").GetComponent<TriggerMealRequest>();
        //starts the timer for the customer and sets the difficulty
        CustomerTimerCoroutine = CustomerTimerCorotine();


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
    //! this currently is used but deletes the plate a needs to changed.
    private void OnTriggerEnter(Collider other)
    {
        //this starts grading when colliding with a plate

        if (other.CompareTag("plate"))
        {
            plateIdentifier givenPlateID = other.gameObject.GetComponent<plateIdentifier>();
            ConfirmOrder(givenPlateID);
        }
    }
    //! remove later
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
//this is the timer for the customer
    IEnumerator CustomerTimerCorotine()
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
        StartCoroutine("delayWindowReset");
        resetIcons();
    }

    void ConfirmOrder(plateIdentifier givenPlate) //Grades the plate by comparing enums Main and Side, Side nums, Rice bool, and coffee(Not Yet Implemented)
    {
        Debug.Log("Confirming Order " + givenPlate + " " + ActualOrder );
        if (givenPlate.plateMain == ActualOrder.Mains
            && givenPlate.plateSide == ActualOrder.sides
            && givenPlate.plateSide1 == ActualOrder.sides1
            && givenPlate.hasRice == ActualOrder.hasRice)
        {
            resetIcons();
            StopCoroutine(CustomerTimerCoroutine);

            CompleteCustomerCorrect();

            FoodNameHeader.text = "Correct";
            ActualOrder = null;
        }
        else//plays inncorect sound when wrong.
        {
            incorrectOrderSound.Play();
            GameManager.instance.WrongOrderTrigger();
            StartCoroutine("youFailed");
        }
        Destroy(givenPlate.gameObject);
    }
    IEnumerator delayWindowReset()
    {
        WindowResetDelay = true;
        yield return new WaitForSeconds(1.0f);
        WindowResetDelay = false;
    }

     public void CompleteCustomerCorrect()
    {
        completeSound.Play();
        GameManager.instance.CorrectOrderTrigger();
        //this is a great...
        Debug.Log(ActualOrder);
        moneyTracker.CalculateAndDisplayMoney(ActualOrder.foodsCostForCustomer);
        CustomerSliderUI.value = 30;
        triggerMeal.UnpauseCustomer();
        StartCoroutine("delayWindowReset");
        resetIcons();
    }
    public void CompleteCustomerTimeRanOut()
    {
        failSound.Play();
        GameManager.instance.OrderTookTooLongTrigger();

    }

    IEnumerator youFailed()
    {
        yield return new WaitForSeconds(3);
        FoodNameHeader.text = ActualOrder.ConfirmedMealName;
    }

    public void MakeAnOrder() //Creates new order when called by TriggerMeal after being triggered by customer
    {
        if(WindowResetDelay == true)
        {
            return;
        }
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