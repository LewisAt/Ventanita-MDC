using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AfterActionReport : MonoBehaviour
{
    [SerializeField] private TMP_Text  TodayEarnings;
    [SerializeField] private GameObject afterActionScreen;
    [SerializeField] private MoneyTracker  moneyTracker;
    void  Start()
    {
        afterActionScreen.SetActive(false);
        GameManager.OnEndDay += ShowAfterAction;
    }

    public void ShowAfterAction()
    {
        afterActionScreen.SetActive(true);

        TodayEarnings.text = "We Saved: " + GameManager.instance.SaveMoney;

    }
    public void startNewDay()
    {
        GameManager.instance.loadNextDay();
    }
}
