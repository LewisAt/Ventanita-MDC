using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AfterActionReport : MonoBehaviour
{
    [SerializeField] private TMP_Text  TodaysSavings;
    [SerializeField] private TMP_Text  TodaysEarnings;
    [SerializeField] private TMP_Text  TodaysGoal;
    [SerializeField] private TMP_Text  Day;
    private GameObject afterActionScreen;
    [SerializeField] private MoneyTracker  moneyTracker;
    void  Start()
    {
        afterActionScreen = transform.GetChild(0).gameObject;
        GameManager.OnEndDay += ShowAfterAction;
        afterActionScreen.SetActive(false);
    }

    public void ShowAfterAction()
    {
        afterActionScreen.SetActive(true);
        TodaysGoal.text = "We Needed: " + GameManager.instance.CurrentMinimumEarnings;
        Day.text = "Day: " + (GameManager.instance.CurrentDay + 1);
        TodaysEarnings.text = "We Earned: " + moneyTracker.daySMoney;
        TodaysSavings.text = "We Saved: " + GameManager.instance.SaveMoney;

    }
    public void startNewDay()
    {
        GameManager.instance.loadNextDay();
    }
    //what day it is
    // how much you needed to earn
    //How much you did earn
    // how much you saved
    //Directions on what to do next.
}
