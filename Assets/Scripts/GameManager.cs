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
    private CustomerManager customerManager;
    private float[] MinimumEarnings = { 100.00f, 200.00f, 300.00f, 400.00f, 500.00f };
    private AfterActionReport afterActionReport;
    private bool runGame = true;
    public bool setRunGame
    {
        get { return runGame;}
        set {
            customerManager.setRunGame = value; 
            afterActionReport
            runGame = value; 
            }

    }
    private int CurrentDifficultyAndDay = 1;
    private float MoneySaved = 0.00f;

    void Awake()
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
        SceneManager.activeSceneChanged += checkIfSceneIsMainGame;
        
    }
    void checkIfSceneIsMainGame(Scene current, Scene next)
    {
        if (next.name != "Main Game")
        {
            Debug.Log("not main game");
            Destroy(gameObject);
            return;
        }
        customerManager = GameObject.Find("GameFunctions(POSITIONSMATTER)/====GameSystems====/CustomerManager1").GetComponent<CustomerManager>();
        //
        if(customerManager == null)
        {
            Debug.Log("CustomerManager not found");
        }
        else
        {
            Debug.Log("CustomerManager found");
        }
    }
    public void endDay()
    {
        setRunGame = false;
        //enable after actionScreen
        //show earnings
        //
    }
    //this trigger by the after actionreport being ended.
    void loadNextDay()
    {
        CurrentDifficultyAndDay++;
        SceneManager.LoadScene("Main Game");
    }
    
}
