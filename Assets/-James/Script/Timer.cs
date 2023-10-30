using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public int minute_1 = 0;
    public int minute_2 = 0;
    public int hour = 5;
    public int hours = 0;
    public Text minuteClock_1;
    public Text minuteClock_2;
    public Text hourClock;

    void Start()
    {
        StartCoroutine("Countdown");
    }

    void Update()
    {
        if (minute_1 == 10)
        {
            minute_1 = 0;
            minute_2++;
        }

        if (minute_2 == 6)
        {
            minute_2 = 0;
            hour++;
            hours++;
        }

        minuteClock_1.text = "" + minute_1;
        minuteClock_2.text = "" + minute_2;
        hourClock.text = "" + hour;
    }

    IEnumerator Countdown()
    {
        while (hours < 6)
        {
            yield return new WaitForSeconds(1);
            minute_1++;
        }

        if (hours == 12)
        {
            EndDay();
        }
    }

    public void EndDay()
    {
        StopCoroutine("Countdown");
        Debug.Log("Day Ends");
        //Ends Day coding here
    }
}
