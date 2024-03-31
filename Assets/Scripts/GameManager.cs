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
    private float[] earningValues = { 2.00f, 4.00f, 6.00f, 8.00f, 10.00f };
    public int CurrentDifficulty = 0;
    public delegate void moneySaved();
    public static event moneySaved OnMoneySaved;
    public delegate void endDay();
    public  static event endDay OnEndDay;


    public delegate void OrderTookTooLong();
    public static event OrderTookTooLong OrderTookTooLongEvent;
    public delegate void CorrectOrder();
    public static event CorrectOrder CorrectOrderEvent;
    public delegate void WrongOrder();
    public static event WrongOrder WrongOrderEvent;

    


    private float minumumEarnings = 123f;
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
            Destroy(gameObject);
        }
        CurrentMinimumEarnings = earningValues[0];
        SceneManager.activeSceneChanged += checkIfSceneIsMainGame;
        
    }
    void Start()
    {
        CalculateDifficultyBasedOnEarnings();
    }
    void CalculateDifficultyBasedOnEarnings()
    {
        if (MoneySaved >= earningValues[0])
        {
            CurrentDifficulty = 1;
        }
        if (MoneySaved >= earningValues[1])
        {
            CurrentDifficulty = 2;
        }
        if (MoneySaved >= earningValues[2])
        {
            CurrentDifficulty = 3;
        }
        if (MoneySaved >= earningValues[3])
        {
            CurrentDifficulty = 4;
        }

    }
    void checkIfSceneIsMainGame(Scene current, Scene next)
    {
        drankCoffee = false;
        if (next.name != "Main Game")
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
    //this trigger by the after actionreport being ended.
    public void loadNextDay()
    {
        if(drankCoffee)
        {
            return;
        }
        m_CurrentDay++;
        Debug.Log("Loading Next Day");
        resetSubscriptions();
        int clampDay = Mathf.Clamp(m_CurrentDay, 0, 4);
        CurrentMinimumEarnings = earningValues[CurrentDifficulty];
        SceneManager.LoadScene("Main Game");
        CalculateDifficultyBasedOnEarnings();
        isGameRunning = true;//! we should make this trigger via the player wanting to
        drankCoffee = true;

    }
    //! since the event is static is lingers for the old world and will call upon that which no long exists
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

    
}
