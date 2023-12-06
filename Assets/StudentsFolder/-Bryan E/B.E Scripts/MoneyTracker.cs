using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyTracker : MonoBehaviour
{
    public static float UserCash = 0.00f;
    public TMP_Text currentCash;
    public TMP_Text totalCashText;
    public float totalMoney = 0.00f;
    public float moneyNeeded = 100.00f;
    public GameObject UpgradeMenu;
    public UpgradeManager upgradeManager;

    void Update()
    {
        currentCash.text = "Current Money $" + UserCash.ToString();
        totalCashText.text = "Money: " + UserCash.ToString();
        totalMoney = UserCash;
    }

    public void LoseCondition()
    {
       if(totalMoney < moneyNeeded)
        {
            SceneManager.LoadScene(2);
        }
       else if (totalMoney >= moneyNeeded)
        {
            UpgradeMenu.SetActive(true);
            upgradeManager.GetComponent<UpgradeManager>().enableRay();

        }
    }
}
