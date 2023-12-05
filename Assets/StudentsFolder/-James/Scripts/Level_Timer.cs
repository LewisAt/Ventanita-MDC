using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

using UnityEngine.InputSystem;

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

    //
    //
    //

    public GameObject[] rayInteractors;
    public float screendistance = 3f;
    public float ScreenTrackSpeed = 5f;
    public float ScreenRotateSpeed = 0.02f;

    //
    //
    //

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
            enableRay();
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
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        DisableeRay();
    }


    //
    //
    //
    //
    //


    void trackHeadPos()
    {
        GameObject mainCamera = Camera.main.gameObject;


        Vector3 PlayerViewingDirection = mainCamera.transform.TransformDirection
        (Vector3.forward) * screendistance;
        PlayerViewingDirection = PlayerViewingDirection + mainCamera.transform.position;

        this.transform.position = Vector3.Lerp(this.transform.position, PlayerViewingDirection, 0.02f);



        Vector3 targetdirection = this.transform.position - mainCamera.transform.position;

        Vector3 ScreenDirectionTowardsPlayer = Vector3.RotateTowards(this.transform.forward, targetdirection, 1f, 0);
        this.transform.rotation = Quaternion.LookRotation(ScreenDirectionTowardsPlayer);
    }
    void enableRay()
    {
        rayInteractors[0].SetActive(true);
        rayInteractors[1].SetActive(true);

    }
    void DisableeRay()
    {


        rayInteractors[0].SetActive(false);
        rayInteractors[1].SetActive(false);

    }

    //public void Restart()
    //{
    //    string currentSceneName = SceneManager.GetActiveScene().name;
    //    SceneManager.LoadScene(currentSceneName);
    //}
}
