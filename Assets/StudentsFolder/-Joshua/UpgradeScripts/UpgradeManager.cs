using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class UpgradeManager : MonoBehaviour
{
    public GameObject[] rayInteractors;
    public float screendistance = 3f;
    public float ScreenTrackSpeed = 5f;
    public float ScreenRotateSpeed = 0.02f;
    public GameObject UpgradeMenu;
    bool ticket = false;
    public TextMeshPro money;
    public static float UserCash = 0.00f;
    public TMP_Text FinalCashAmount;


void Start()
    {
        UpgradeMenu.SetActive(false);
    }

    void Update()
    {
        FinalCashAmount.text = "Current Money $" + UserCash.ToString();
    }

    public void Upgrade()
    {
        UpgradeMenu.SetActive(true);
        Time.timeScale = 0f;
        enableRay();
    }

    public void Continue()
    {
        if (ticket == false)
        {
            UpgradeMenu.SetActive(false);
            Time.timeScale = 1f;
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
            DisableeRay();
        }
        
        if(ticket == true)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void BuyTicket()
    {
         ticket = true;
    }


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
}
