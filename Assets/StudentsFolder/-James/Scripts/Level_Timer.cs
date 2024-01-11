using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

using UnityEngine.InputSystem;

public class Level_Timer : MonoBehaviour
{
    //Variables
    public int minute_1 = 0;
    public int minute_2 = 0;
    public int hour = 6;
    public TMP_Text minuteClock_1;
    public TMP_Text minuteClock_2;
    public TMP_Text hourClock;
    public AudioSource endTimerSound;
    bool DayEnd = false;
    public UpgradeManager upgradeManager;

    //Starts Coroutine
    void Start()
    {
        StartCoroutine("Countdown");
    }

    void Update()
    {
        //Manages Clock (Where 1 is placed: 0:01)
        if (minute_1 < 0)
        {
            minute_1 = 9;
            minute_2--;
        }

        //Manages Clock (Where 1 is placed: 0:10)
        if (minute_2 < 0)
        {
            minute_2 = 5;
            hour--;
        }

        //Updates Text
        minuteClock_1.text = "" + minute_1;
        minuteClock_2.text = "" + minute_2;
        hourClock.text = "" + hour;

        //sound
        if (hour == 0 && minute_2 == 1 && minute_1 == 2)
        {
            endTimerSound.Play();
        }

        //Begins End Day
        if (hour == 0 && minute_2 == 0 && minute_1 == 0 && DayEnd == false)
        {
            DayEnd = true;
            StopCoroutine("Countdown");
            EndDay();
            upgradeManager.GetComponent<UpgradeManager>().Upgrade();
        }
    }

    //Countdown
    IEnumerator Countdown()
    {
        DayEnd = false;
        while (hour >= 0)
        {
            yield return new WaitForSeconds(1);
            minute_1--;
        }
    }

    //End Day
    public void EndDay()
    {
        Debug.Log("Day Ends");
        //Ends Day coding here

    }
}
