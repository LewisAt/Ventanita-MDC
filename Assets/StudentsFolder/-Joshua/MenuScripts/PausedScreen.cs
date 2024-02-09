using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PausedScreen : MonoBehaviour
{
    public InputActionReference showButton;
    public GameObject pauseMenu;
    public bool isPaused;
    public float screendistance = 3f;
    public float ScreenTrackSpeed = 5f;
    public float ScreenRotateSpeed = 0.02f;
    public GameObject[] rayInteractors;


    // Start is called before the first frame update
    void Start()
    {
        //Sets the pause menu to false when the game starts
        pauseMenu.SetActive(false);
        isPaused = false;
        //Disables ray interactor for ui when the game starts
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
        //Checks to see if a button was pressed in the console
        Debug.Log(showButton.action.WasPerformedThisFrame());
        //Checks to see if the assigned button has been pressed, as well as if the isPaused variable is false
        if(showButton.action.WasPressedThisFrame() && isPaused == false)
        {
            PauseGame();
            //Enables the ray interactor so the player is able to interactor with the UI
            enableRay();
        }
        //Checks to see if the assigned button has been pressed, as well as if the isPaused variable is true;
        else if (showButton.action.WasPressedThisFrame() && isPaused == true)
        {
            // pauseMenu.SetActive(!pauseMenu.activeSelf);
            //Time.timeScale = 1.0f;
            //isPaused = false;
            //If the else if statement is true, meaning that the game is already paused, pressing the assigned button again will continue the game by deactivating the the pause menu
            ContinueGame();
            //Disables the ray interactor so the player can properly interact with the environment
            DisableeRay();
        }
        //Tracks the position of the players head/camera
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
    
    //Activates the ray interactors for both the left and right controller
    void enableRay()
    {
        rayInteractors[0].SetActive(true);
        rayInteractors[1].SetActive(true);
        
    }

    //deactivates the ray interactors for both the left and right controller
    void DisableeRay()
    {


        rayInteractors[0].SetActive(false);
        rayInteractors[1].SetActive(false);

    }

    //Activates the pause menu gameobject 
    public void PauseGame()
    {
        //Sets the pause menu gameobject to the opposite of its activeself, so if the pause menu is not active, it would be set to active
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        //Sets the timescale to 0, freezing the game timer, objects in motion, as well as other game objects being used
        Time.timeScale = 0f;
        isPaused = true;
    }

    //deactivates the pause menu gameobject
    public void ContinueGame()
    {
        //Sets the pause menu gameobject to the opposite of its activeself, so if the pause menu is active, it would deactivate it
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        isPaused = false;
        //Sets the timescale to 1, unfreezing the game timer, objects in motion, as well as other game objects in use
        Time.timeScale = 1f;
    }

    //Sends the player to a different scene
    public void ToMenu()
    {
        Time.timeScale = 1f;
        //Load the scene that matches the scene number referenced in the script
        SceneManager.LoadScene(0);
    }

    //Closes the game 
    public void QuitGame()
    {
        //Quits the current application being used
        Application.Quit();
        Debug.Log("Quit");
    }
}