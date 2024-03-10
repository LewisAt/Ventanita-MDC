using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Plane_Ticket : MonoBehaviour
{
    public int TicketCost = 150;

    [SerializeField]
    MoneyTracker pMoney;

    public Text totalPrice;
    public Text remainder;

    void Update()
    {
        //remainder.text = "" + pMoney.totalMoney;
    }

    public void Purchase()
    {
        /* if (pMoney.totalMoney >= TicketCost)
        {
            StartCoroutine("Wait");
        } */
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        Win();
    }

    public void Win()
    {
        //Starts Win Condition
    }
}
