using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject wristUI;

    public bool activeWristUI = true;

    // Start is called before the first frame update
    void Start()
    {
        DisplayWristUI();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseButtonOnPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            DisplayWristUI();
    }

    public void DisplayWristUI()
    {
        if(activeWristUI)
        {
            wristUI.SetActive(false);
            activeWristUI = false;
            Time.timeScale = 1;
        }
        else if(!activeWristUI)
        {
            wristUI.SetActive(true);
            activeWristUI = true;
            Time.timeScale = 0;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
