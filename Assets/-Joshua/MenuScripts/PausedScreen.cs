using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PausedScreen : MonoBehaviour
{
    public InputActionProperty showButton;
    public GameObject pauseMenu;
    public bool isPaused;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
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
        if(showButton.action.WasPressedThisFrame())
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
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