using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;

//! the thing that controls what ends the day is the level_timer which is
//! located in the gameplay Objects called GameTimer

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool IsTutorialOn = false;
    //^ Jar display has its own values to set to if they miss match go there.
    private float[] earningValues = { 5.0f, 20f, 40, 60f, 100f};
    public int CurrentDifficulty = 0;
    public delegate void moneySaved();
    public static event moneySaved OnMoneySaved;
    public delegate void endDay();
    public  static event endDay OnEndDay;
    public float RegisterCashAmount = 0.00f;

    private bool isInTheRed = false;


    public delegate void OrderTookTooLong();
    public static event OrderTookTooLong OrderTookTooLongEvent;
    public delegate void CorrectOrder();
    public static event CorrectOrder CorrectOrderEvent;
    public delegate void WrongOrder();
    public static event WrongOrder WrongOrderEvent;

    


    private float minumumEarnings = 0;
    public float CurrentMinimumEarnings
    {
        get{return minumumEarnings;}
        set{minumumEarnings = value;}
    }
    private bool runGame = true;
    public bool isGameRunning
    {
        get { return runGame;}
        set { 
            runGame = value; 
            }

    }
    private int CurrentDay = 0;
    public int m_CurrentDay
    {
        get { return CurrentDay; }
        set { CurrentDay = value; }
    }
    //& this to defend agains the fact that the coffee cup sometimes triggers twice
    private bool drankCoffee = false;


    


    private float MoneySaved = 0.00f;

    //!if for some reason the code doesn't update the jar this c 
    public float SaveMoney
    {
        get { return MoneySaved; }
        set {
            OnMoneySaved(); 
            MoneySaved = value; }
    }

    void  Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            instance.CalculateDifficultyBasedOnEarnings();
            Destroy(gameObject);
        }
        SceneManager.activeSceneChanged += checkIfSceneIsMainGame;
        
    }
    public void Debugwin()
    {
        SaveMoney = 300;
    }
    bool tempDebug = false;
    //!!!!!!!!!!!!!!!!!!!! this Update is temporary remove me!!!!!!!!!!!!!!!!!!!!!!!!!
    // i killed it were safe you can breathe now....
    public  void CalculateDifficultyBasedOnEarnings()
    {
        if(isInTheRed)
        {
            int temp = TempDifficulty - 1;
            if(temp < 0)
            {
                temp = 0;
            }
            CurrentDifficulty = temp;
            CurrentMinimumEarnings = earningValues[temp];
            return;
        }
        
        if (SaveMoney <= 0)
        {
            CurrentDifficulty = 0;
            CurrentMinimumEarnings = earningValues[0];
        } 
        if (RegisterCashAmount >= earningValues[0])
        {
            CurrentDifficulty = 1;
            CurrentMinimumEarnings = earningValues[1];
        }
        if (RegisterCashAmount >= earningValues[1])
        {
            CurrentDifficulty = 2;
            CurrentMinimumEarnings = earningValues[2];
        }
        if (RegisterCashAmount >= earningValues[2])
        {
            CurrentDifficulty = 3;  
            CurrentMinimumEarnings = earningValues[3];
        }
        if (RegisterCashAmount >= earningValues[3])
        {
            CurrentDifficulty = 4;
            CurrentMinimumEarnings = earningValues[4];
        }
    }

    //!!
    //!!
    //!! THE FOLLOWING CODE IS A MESS BUT
    //!! The value that checks to see if the scene is the main game is not being triggered
    //!! is in the customer manager Script 
    //!! fucking hilarious I KNOW...






    //! THis is the worse solution but is one

    int TempDifficulty;

    //* This is virtually our awake method and gets called everytime. lets see if it works though
    void checkIfSceneIsMainGame(Scene current, Scene next)
    {
        tempDebug  = true;
        drankCoffee = false;
        CalculateDifficultyBasedOnEarnings();
        if (next.name != "Main Game" && !IsTutorialOn)
        {
            
            Debug.Log("not main game");
            Destroy(gameObject);
            return;
        }
        //! if you have issues finding this attach it to the timer instead
        //
    }
    public void EndDay()
    {

        isGameRunning = false;
        Debug.Log("Day Ended");
        OnEndDay();
        //enable after actionScreen
        //show earnings
    }
    private void resetImportantValues()
    {
        SaveMoney = 0.00f;
        CurrentDay = 0;
        CurrentDifficulty = 0;
        CurrentMinimumEarnings = earningValues[0];
    }
    //this trigger by the after actionreport being ended.
    public void loadNextDay()
    {
        if(drankCoffee)
        {
            return;
        }
        
        if(isInTheRed && SaveMoney > 0)
        {
            
            isInTheRed = false;
        }
        else if(isInTheRed && SaveMoney < 0)
        {
            Debug.Log("You have gone into the red and could not recover");
            SceneManager.LoadScene(5);
            return;
        }
        if(SaveMoney < 0)
        {
            Debug.Log("You have gone into the red");
            TempDifficulty = CurrentDifficulty;
            isInTheRed = true;
        }
        
        //!give the player some kind of warning or something in the next day
        
        m_CurrentDay++;
        Debug.Log("Loading Next Day");
        resetSubscriptions();
        int ClampDiff = Mathf.Clamp(CurrentDifficulty, 0, 4);
        CurrentMinimumEarnings = earningValues[ClampDiff];
        CalculateDifficultyBasedOnEarnings();

        RegisterCashAmount = 0.00f;
        if(SaveMoney > 300)
        {
            Debug.Log("You have saved enough money to buy the ticket");
            SceneManager.LoadScene(4);
            EndGame();
            return;
        }
        SceneManager.LoadScene("Main Game");
        isGameRunning = true;//! we should make this trigger via the player wanting to
        drankCoffee = true;

    }
    //! since the event is static is lingers for the old world and will call upon that which no longer exists
    //& basically when you call the event it tries to call all the previous
    //&Subscriptions that were made to it.
    //&since that scenes was deloaded it will cause a null reference exception
    public void resetSubscriptions()
    {
        OnEndDay = null;
        OnMoneySaved = null;
        OrderTookTooLongEvent = null;
        CorrectOrderEvent = null;
        WrongOrderEvent = null;
    }
//& ahead is the ugliest pieces of code you will ever see. Beware all ye who enter here

    public void OrderTookTooLongTrigger()
    {
        OrderTookTooLongEvent();
    }
    public void CorrectOrderTrigger()
    {
        CorrectOrderEvent();
    }
    public void WrongOrderTrigger()
    {
        WrongOrderEvent();
    }
    void EndGame()
    {
        resetImportantValues();
        resetSubscriptions();
        Destroy(gameObject);
    }

    
}
