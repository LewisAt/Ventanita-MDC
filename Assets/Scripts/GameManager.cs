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
    private float[] earningValues = { 100.00f, 200.00f, 300.00f, 400.00f, 500.00f };
    public delegate void moneySaved();
    public static event moneySaved OnMoneySaved;
    public delegate void endDay();
    public static event endDay OnEndDay;

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
    private int CurrentDifficultyAndDay = 0;
    private float MoneySaved = 0.00f;

    //!if for some reason the code doesn't update the jar this could be the issue 
    public float SaveMoney
    {
        get { return MoneySaved; }
        set {
            OnMoneySaved(); 
            MoneySaved = value; }
    }

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
        startNewDay();
        //! if you have issues finding this attach it to the timer instead
        //
    }
    void startNewDay()
    {
        CurrentMinimumEarnings = earningValues[CurrentDifficultyAndDay];
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
        CurrentDifficultyAndDay++;
        SceneManager.LoadScene("Main Game");
    }
    
}
