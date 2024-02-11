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
    public float coffeeUpgradeCost = 30.00f;
    public GameObject UpgradeMenu;
    //public float newAmount;
    public UpgradeManager upgradeManager;
    public CustomerOrder customerOrder;
    public TMP_Text WarningSplash;
    //For saving money between scenes and changing difficulty
    DifficultyDirector difficultyDirector;

    [SerializeField]
    Plane_Ticket calc;
    private void Start()
    {
        difficultyDirector = GameObject.FindGameObjectWithTag("DifficultyDirector").GetComponent<DifficultyDirector>();
    }

    //shows user current cash and sets the total amount of cash.
    void Update()
    {
        currentCash.text = "Current Money $" + UserCash.ToString();
        totalCashText.text = "Money: $" + UserCash.ToString();
        totalMoney = UserCash;
        totalCashText.text = (totalMoney - moneyNeeded).ToString();
    }

    //decides wether player loses or goes to upgrade screen depending on total money
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
            calc.Purchase();
        }
    }

    //tells player how they can win or lose
    private void Awake()
    {
        WarningSplash.text = "Earn " + moneyNeeded.ToString() + "$\n or lose";
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
    private void OnDestroy() //If Total money exceeds easy money goal after scene then higher difficulty
    {
        difficultyDirector.saveMoney(totalMoney);
    }
}
