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
    [SerializeField] private float DayLengthinMinutes = 4;
    private int seconds = 60;
    [SerializeField] private TMP_Text TimerText;

    //Starts Coroutine
    void Start()
    {
    }
    void triggerStartDay()
    {
        StartCoroutine("Countdown");
    }

    //Countdown

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        seconds--;
        if (seconds == 0)
        {
            DayLengthinMinutes--;
            seconds = 60;
        }
        if (DayLengthinMinutes == 0 && seconds == 0)
        {
            EndDay();
        }

    }

    //End Day
    public void EndDay()
    {

        Debug.Log("Day Ends");
        GameManager.instance.endDay();
        //Ends Day coding here
        //stop all customersc
        //enable after actionScreen
        //disable all other screens

    }
}
