using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer_Timer : MonoBehaviour
{
    public int timer = 45;
    public Slider slider;

    void Start()
    {
        StartCoroutine("TimerCustomer");
    }

    void Update()
    {
        slider.value = timer;
    }

    IEnumerator TimerCustomer()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1);
            timer--;
        }

        if (timer == 0)
        {
            StopCoroutine("TimerCustomer");
            Debug.Log("The Wild Customer runs away.");
            //Sends info for customer to leave window and order ends
        }
    }
}
