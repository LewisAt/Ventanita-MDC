using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer_Timer : MonoBehaviour
{
    //Variables
    public int timer = 45;
    public Slider slider;

    //Starts Coroutine
    void Start()
    {
        StartCoroutine("TimerCustomer");
    }

    //Updates Slider Value
    void Update()
    {
        slider.value = timer;
    }

    //Customer Timer
    IEnumerator TimerCustomer()
    {
        // Countdown
        while (timer > 0)
        {
            yield return new WaitForSeconds(1);
            timer--;
        }

        //Stops Timer
        if (timer == 0)
        {
            StopCoroutine("TimerCustomer");
        }
    }
}
