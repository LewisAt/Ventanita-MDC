using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarDisplay : MonoBehaviour
{
    /// <summary>
    /// The amount of money currently saved.
    /// </summary>
    private float currentMoneySaved;

    private float moneyState0 = 0;
    private float moneyState1 = 200;
    private float moneyState2 = 400;
    private float moneyState3 = 600;
    private float moneyStateLast = 800;

    /// <summary>
    /// Gets or sets the current amount of money saved.
    /// </summary>
    public float CurrentMoneySaved
    {
        get { return currentMoneySaved; }
        set
        {
            currentMoneySaved = value;
            upddateDisplayAmount();
        }
    }

    void Awake()
    {
        GameManager.OnMoneySaved += upddateDisplayAmount;
    }

    public GameObject DisplayState1;
    public GameObject DisplayState2;
    public GameObject DisplayState3;
    public GameObject DisplayStatelast;

    /// <summary>
    /// Updates the display amount based on the current money saved.
    /// </summary>
    void upddateDisplayAmount()
    {
        currentMoneySaved = GameManager.instance.SaveMoney;
        if (CurrentMoneySaved == moneyState0)
        {
            DisplayState1.SetActive(false);
            DisplayState2.SetActive(false);
            DisplayState3.SetActive(false);
            DisplayStatelast.SetActive(false);
        }
        else if (CurrentMoneySaved > moneyState1)
        {
            playMoneySFX();
            DisplayState1.SetActive(true);
            DisplayState2.SetActive(false);
            DisplayState3.SetActive(false);
            DisplayStatelast.SetActive(false);
        }
        else if (CurrentMoneySaved > moneyState2)
        {
            playMoneySFX();
            DisplayState1.SetActive(false);
            DisplayState2.SetActive(true);
            DisplayState3.SetActive(false);
            DisplayStatelast.SetActive(false);
        }
        else if (CurrentMoneySaved > moneyState3)
        {
            playMoneySFX();
            DisplayState1.SetActive(false);
            DisplayState2.SetActive(false);
            DisplayState3.SetActive(true);
            DisplayStatelast.SetActive(false);
        }
        else if (CurrentMoneySaved > moneyStateLast)
        {
            playMoneySFX();
            DisplayState1.SetActive(false);
            DisplayState2.SetActive(false);
            DisplayState3.SetActive(false);
            DisplayStatelast.SetActive(true);
        }
    }

    /// <summary>
    /// Plays the appropriate sound effect and particle effect based on the current money saved.
    /// </summary>
    void playMoneySFX()
    {
        if (CurrentMoneySaved > moneyState1)
        {
            //play sound effect & Particle effect
        }
        else if (CurrentMoneySaved > moneyState2)
        {
            //play sound effect & Particle effect
        }
        else if (CurrentMoneySaved > moneyState3)
        {
            //play sound effect & Particle effect
        }
        else if (CurrentMoneySaved > moneyStateLast)
        {
            //play sound effect & Particle effect
        }
    }



}
