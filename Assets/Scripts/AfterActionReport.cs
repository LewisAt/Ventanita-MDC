using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AfterActionReport : MonoBehaviour
{
    [SerializeField] private TMP_Text  TodayEarnings;
    [SerializeField] private GameObject afterActionScreen;
    [SerializeField] private MoneyTracker  moneyTracker;
    void Awake()
    {
        afterActionScreen.SetActive(false);
    
    }

    public void ShowAfterAction()
    {

        TodayEarnings.text = "Today's Earnings: " + moneyTracker.daySMoney;
    }
    void triggerEndDay()
    {
        
    }
}
