using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarDisplay : MonoBehaviour
{
    private float currentMoneySaved;

    public float moneyState0;
    public float moneyState1;
    public float moneyState2;
    public float moneyState3;
    public float moneyStateLast;
    public float CurrentMoneySaved
    
    {
        get { return currentMoneySaved; }
        set { 
            currentMoneySaved = value; 
            upddateDisplayAmount();
            }
        
    }
    void Awake()
    {
        GeneralManager.instance.SetMoneySaved(0);
    }
    public GameObject DisplayState1;
    public GameObject DisplayState2;
    public GameObject DisplayState3;
    public GameObject DisplayStatelast;
    void upddateDisplayAmount()
    {
        if(CurrentMoneySaved == moneyState0)
        {
            playMoneySFX();
            DisplayState1.SetActive(false);
            DisplayState2.SetActive(false);
            DisplayState3.SetActive(false);
            DisplayStatelast.SetActive(false);
        }
        else if(CurrentMoneySaved > moneyState1)
        {
            playMoneySFX();
            DisplayState1.SetActive(true);
            DisplayState2.SetActive(false);
            DisplayState3.SetActive(false);
            DisplayStatelast.SetActive(false);
        }
        else if(CurrentMoneySaved > moneyState2)
        {
            playMoneySFX();
            DisplayState1.SetActive(false);
            DisplayState2.SetActive(true);
            DisplayState3.SetActive(false);
            DisplayStatelast.SetActive(false);
        }
        else if(CurrentMoneySaved > moneyState3)
        {
            playMoneySFX();
            DisplayState1.SetActive(false);
            DisplayState2.SetActive(false);
            DisplayState3.SetActive(true);
            DisplayStatelast.SetActive(false);
        }
        else if(CurrentMoneySaved > moneyStateLast)
        {
            playMoneySFX();
            DisplayState1.SetActive(false);
            DisplayState2.SetActive(false);
            DisplayState3.SetActive(false);
            DisplayStatelast.SetActive(true);
            TriggerEndGameState();
        }
    }

    void playMoneySFX()
    {
        if(CurrentMoneySaved > moneyState1)
        {
            //play sound effect & Particle effect
        }
        else if(CurrentMoneySaved > moneyState2)
        {
            //play sound effect & Particle effect
        }
        else if(CurrentMoneySaved > moneyState3)
        {
            //play sound effect & Particle effect
        }
        else if(CurrentMoneySaved > moneyStateLast)
        {
            //play sound effect & Particle effect
        }
    }
    void TriggerEndGameState()
    {
        if(CurrentMoneySaved > moneyStateLast)
        {
            //Trigger End Game State
        }
    }
}
