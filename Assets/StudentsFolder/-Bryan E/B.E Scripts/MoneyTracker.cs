using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MoneyTracker : MonoBehaviour
{
    [SerializeField] private TMP_Text RegisterCashAmount;
    [SerializeField] private TMP_Text JarCahsAmount;
    private float DaysMoney = 0.00f;
    public float daySMoney
    {
        get { return DaysMoney; }
        set { 
            //^ We still need to save this value and get it from the save file
            //^ or the general manager.
            UpdateJarDisplay();
            DaysMoney = value; 
            }
    }
    private float savedTotal = 0.00f;
    public float totalMoney
    {
        get { return savedTotal; }
        set { 
            UpdateRegisterDisplay();
            savedTotal = value; 
            }
    }
    public void CalculateAndDisplayMoney(float foodCost)
    {
        //^ We need to calculate the money earned from the day and display it.
        //^ We also need to save the money to the save file or the game manager.
        //^ We also need to end the day and go to the next day.
        
    }

    void UpdateRegisterDisplay()
    {
        RegisterCashAmount.text = "Register\n$" + RegisterCashAmount.ToString();
    }
    void UpdateJarDisplay()
    {
        JarCahsAmount.text = "Jar\n$" + JarCahsAmount.ToString();
    }
    void EndDayAndSaveMoney()
    {
        //^ We need to save the money to the save file or the general manager.
        //^ We also need to end the day and go to the next day.
        //! calcaute how much money to save at the end of day based on how
        //! much money more was exceed. so if it cost 400$ to pass - from saved
        //! if less subtract from saved
    }
}
