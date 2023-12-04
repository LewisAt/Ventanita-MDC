using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Level_Timer : MonoBehaviour
{
    public int minute_1 = 0;
    public int minute_2 = 0;
    public int hour = 6;
    public TMP_Text minuteClock_1;
    public TMP_Text minuteClock_2;
    public TMP_Text hourClock;
    public AudioSource endTimerSound;
    bool DayEnd = false;
    public GameObject UpgradeMenu;

    void Start()
    {
        StartCoroutine("Countdown");
        UpgradeMenu.SetActive(false);
    }

    void Update()
    {
        if (minute_1 < 0)
        {
            minute_1 = 9;
            minute_2--;
        }

        if (minute_2 < 0)
        {
            minute_2 = 5;
            hour--;
        }

        minuteClock_1.text = "" + minute_1;
        minuteClock_2.text = "" + minute_2;
        hourClock.text = "" + hour;

        //sound
        if (hour == 0 && minute_2 == 1 && minute_1 == 2)
        {
            endTimerSound.Play();
        }

        if (hour == 0 && minute_2 == 0 && minute_1 == 0 && DayEnd == false)
        {
            DayEnd = true;
            StopCoroutine("Countdown");
            EndDay();
            Upgrade();
        }
    }

    IEnumerator Countdown()
    {
        DayEnd = false;
        while (hour >= 0)
        {
            yield return new WaitForSeconds(1);
            minute_1--;
        }
    }

    public void EndDay()
    {
        Debug.Log("Day Ends");
        //Ends Day coding here

    }

    public void Upgrade()
    {
        UpgradeMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        UpgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        hour = 6;
        StartCoroutine("Countdown");
    }
}
