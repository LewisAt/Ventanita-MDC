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
    [SerializeField] AfterActionReport afterActionReport;

    private float DaysTotal = 0.00f;
    public float daySMoney
    {
        get { return DaysTotal; }
        set { 
            DaysTotal = value; 
            }
    }
    public void CalculateAndDisplayMoney(float foodCost)
    {
        daySMoney += foodCost;
        UpdateRegisterDisplay();
        if(GameManager.instance.CurrentMinimumEarnings < DaysTotal)
        {
            GameManager.instance.SaveMoney += foodCost;
        }

        
    }

    void UpdateRegisterDisplay()
    {
        RegisterCashAmount.text = "Register\n$" + RegisterCashAmount.ToString();
    }
    void EndDay()
    {
        //^ We need to save the money to the save file or the general manager.
        //^ We also need to end the day and go to the next day.
        //! calcaute how much money to save at the end of day based on how
        //! much money more was exceed. so if it cost 400$ to pass - from saved
        //! if less subtract from saved
    }
}
