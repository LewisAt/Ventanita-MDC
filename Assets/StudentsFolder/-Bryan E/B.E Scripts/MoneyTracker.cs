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
    private float temp = 2;
    [HideInInspector]
    public float currentDayTotal = 0.00f;
    public bool Welostmoney = false;

    void Start()
    {
        RegisterCashAmount.text = "Register\n$" + currentDayTotal + 
        "\n you need $" + GameManager.instance.CurrentMinimumEarnings + " to end the day" +
        "\n you have $" + GameManager.instance.SaveMoney + " in savings";
        temp = GameManager.instance.CurrentMinimumEarnings;
    }
    public void setDayOver()
    {
        if(currentDayTotal < GameManager.instance.CurrentMinimumEarnings)
        {
            Welostmoney = true;
            GameManager.instance.SaveMoney += currentDayTotal - GameManager.instance.CurrentMinimumEarnings; 
        }
    }   

    public void CalculateAndDisplayMoney(float foodCost)
    {
        currentDayTotal += foodCost;
        GameManager.instance.RegisterCashAmount = currentDayTotal;
        // we need a statement that checks if the money is greater than the minimum
        // but just barely because it will add the total food amount if it is 
 

        UpdateRegisterDisplay();
        if(currentDayTotal >= GameManager.instance.CurrentMinimumEarnings)
        {
            float valueToadd = currentDayTotal - temp;
            temp = currentDayTotal;
            GameManager.instance.SaveMoney += valueToadd;
        }
            
        
    }

    void UpdateRegisterDisplay()
    {
        RegisterCashAmount.text = "Register$" + currentDayTotal + 
        "\n you need $" + GameManager.instance.CurrentMinimumEarnings + " to end the day";


    }
}
