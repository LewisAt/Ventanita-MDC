using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PausedScreen : MonoBehaviour
{
    public InputActionProperty showButton;
    public GameObject pauseMenu;
    public bool isPaused;
    public float screendistance = 3f;
    public float ScreenTrackSpeed = 5f;
    public float ScreenRotateSpeed = 0.02f;
    public GameObject[] rayInteractors;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        DisableeRay();


    }

    // Update is called once per frame
    //public void PauseButtonOnPressed(InputAction.CallbackContext context)
    ////void Update()
    //{
    //    //if (Input.GetKeyDown(KeyCode.Escape)) 
    //    if (context.performed)
    //    {
    //        /*if(isPaused)
    //        {
    //            ContinueGame();
    //        }

    //        else
    //        {
    //            PauseGame();
    //        }
    //        */
    //        PauseGame();
    //    }
    //}

    void Update()
    {
        if(showButton.action.WasPressedThisFrame() && isPaused == false)
        {
            PauseGame();
            enableRay();
        }
        else if (showButton.action.WasPressedThisFrame() && isPaused == true)
        {
            // pauseMenu.SetActive(!pauseMenu.activeSelf);
            //Time.timeScale = 1.0f;
            //isPaused = false;
            ContinueGame();
            DisableeRay();
        }
        
        trackHeadPos();

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

    public void PauseGame()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void ToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}