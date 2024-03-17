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
    [SerializeField] private float DayLengthinMinutes = 0;
    [SerializeField] private int seconds = 60;
    [SerializeField] private TMP_Text TimerText;

    //Starts Coroutine
    void Start()
    {
        //!change it so they drink coffee to start the day.
        StartCoroutine("Countdown");

    }
    void triggerStartDay()
    {
    }

    //Countdown
    private bool RunCountdown = true;
    IEnumerator Countdown()
    {
        while (RunCountdown)
        {
            //Debug.Log(DayLengthinMinutes + ":" + seconds);
             yield return new WaitForSeconds(1);
            seconds--;
            TimerText.text = DayLengthinMinutes + ":" + seconds;
            if(seconds < 10)
            {
                TimerText.text = DayLengthinMinutes + ":0" + seconds;
            }
            if (DayLengthinMinutes == 0 && seconds == 0)
            {
                Debug.Log("time is up!");
                GameManager.instance.EndDay();
                RunCountdown = GameManager.instance.isGameRunning;
                yield break;
            }
            if (seconds == 0)
            {
                Debug.Log("Minute is up!");
                DayLengthinMinutes--;
                seconds = 60;
            }
            


        }
       
    }

    //End Day
}
