using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AfterActionReport : MonoBehaviour
{
    [SerializeField] private TMP_Text  TodaysSavings;
    [SerializeField] private TMP_Text  TodaysEarnings;
    [SerializeField] private TMP_Text  TodaysGoal;
    private bool drankCoffee = false;
    [SerializeField] private TMP_Text  Day;
    [SerializeField] private AudioSource LookAtTheAfterActionReport;
    private GameObject afterActionScreen;
    private GameObject CoffeeCup;
    [SerializeField] private MoneyTracker  moneyTracker;
    void  Start()
    {
        afterActionScreen = transform.GetChild(0).gameObject;
        CoffeeCup = transform.GetChild(1).gameObject;
        GameManager.OnEndDay += ShowAfterAction;
        afterActionScreen.SetActive(false);
        CoffeeCup.SetActive(false);

    }

    public void ShowAfterAction()
    {
        afterActionScreen.SetActive(true);
        CoffeeCup.SetActive(true);
        StartCoroutine(DelaySound());
        TodaysGoal.text = "We Needed: " + GameManager.instance.CurrentMinimumEarnings;
        int day = GameManager.instance.m_CurrentDay + 1;
        Day.text = "Day: " + (day);
        TodaysEarnings.text = "We Earned: " + moneyTracker.daySMoney;
        TodaysSavings.text = "We have " + GameManager.instance.SaveMoney + "$ in savings";

    }
    IEnumerator DelaySound()
    {
        yield return new WaitForSeconds(3.0f);
        LookAtTheAfterActionReport.Play();
    }

    //what day it is
    // how much you needed to earn
    //How much you did earn
    // how much you saved
    //Directions on what to do next.
}
