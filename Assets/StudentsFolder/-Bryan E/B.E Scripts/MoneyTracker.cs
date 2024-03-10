using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyTracker : MonoBehaviour
{
    public float UserCash = 0.00f;
    public TMP_Text currentCash;
    private float totalMoney = 0.00f;
    private float moneyNeeded = 100.00f;
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

    //decides wether player loses or goes to upgrade screen depending on total money
    // public void LoseCondition()
    // {
    //    if(totalMoney < moneyNeeded)
    //     {
    //         SceneManager.LoadScene(2);
    //     }
    //    else if (totalMoney >= moneyNeeded)
    //     {
    //         UpgradeMenu.SetActive(true);
    //     }
    // }

    //tells player how they can win or lose
    private void Awake()
    {
        //WarningSplash.text = "Earn " + moneyNeeded.ToString() + "$\n or lose";
        //StartCoroutine(playWarning());
    }
    /*IEnumerator playWarning()
    {
        for(int i = 0; i < 13 ; i++) 
        {
            yield return new WaitForSeconds(0.4f);
            WarningSplash.gameObject.SetActive(!WarningSplash.gameObject.activeSelf);
        }     
    }*/

    //public void coffeePayment()
    //{
    //    if(totalMoney >= coffeeUpgradeCost)
    //    {
    //        newAmount = UserCash - coffeeUpgradeCost;
    //        totalCashText.text = "Money: $" + newAmount.ToString();
    //    }
    //    //totalMoney = UserCash - coffeeUpgradeCost;
    //    //totalCashText.text = "Money: $" + totalMoney.ToString();
    //}
}
