using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class rogerTimer : MonoBehaviour
{
    public int time = 60;
    public Text timeLeft;

    void Update()
    {
        // ends game
        if (time == 0)
        {
            //Game Over - Back to menu
            //SceneManager.LoadScene("Menu");

        }
        timeLeft.text = "" + time;
    }

    //Button on radio is pressed
    public void OnTriggerEnter(Collider other)
    {
        // Level is already selected radio just starts it
        //SceneManager.LoadScene("Level 1");
        StartCoroutine("Countdown");
       
    }
    IEnumerator Countdown()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
        }
    }
}
