using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyTracker : MonoBehaviour
{
    public TMP_Text currentCash;
    private float totalMoney = 0.00f;
    // public GameObject UpgradeMenu;
    //public float newAmount;
    // public UpgradeManager upgradeManager;
    public TMP_Text WarningSplash;

    //shows user current cash and sets the total amount of cash.
    void Update()
    {
        currentCash.text = "Current Money\n$" + UserCash.ToString();
        totalMoney = UserCash;
    }
    v
    void Start()
    {
        currentCash.text = "Current Money\n$" + UserCash.ToString();
        totalMoney = UserCash;
    }
}
