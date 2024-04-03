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
    [SerializeField] RadioSystem radio;
    [SerializeField] private int seconds = 60;
    [SerializeField] private TMP_Text TimerText;
    [SerializeField] private AudioSource timerSound;
    [SerializeField] private MoneyTracker theMONSTER;

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
          /*   if(radio.radioOutroCheck.length <= seconds && radio.radioOutroCheck.length > 0)
            {
                radio.PlayEnding();
            } */
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
                theMONSTER.setDayOver();
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
            if(DayLengthinMinutes == 0 && seconds == 10)
            {
                TimerText.color = Color.red;
                if(!timerSound.isPlaying)
                {
                    timerSound.Play();
                }
            
            }
            


        }
       
    }

    //End Day
}
