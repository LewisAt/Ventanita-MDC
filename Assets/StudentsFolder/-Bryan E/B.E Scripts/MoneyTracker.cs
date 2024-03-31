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
        // we need a statement that checks if the money is greater than the minimum
        // but just barely because it will add the total food amount if it is 
 
        UpdateRegisterDisplay();
        if(GameManager.instance.CurrentMinimumEarnings < DaysTotal)
        {
            float moneyToSave = DaysTotal - GameManager.instance.CurrentMinimumEarnings;
            float Inputted = moneyToSave - GameManager.instance.SaveMoney;
            GameManager.instance.SaveMoney += Inputted;
        }

        
    }

    void UpdateRegisterDisplay()
    {
        RegisterCashAmount.text = "Register\n$" + DaysTotal;
    }
}
