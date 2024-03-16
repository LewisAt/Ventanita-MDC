using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralManager : MonoBehaviour
{

    //this is related to the number of days completed
    // 1 = day 1, 2 = day 2, etc.

    // False = snap turning, True = smooth turning
    private bool currentTurningMode = false;

    public static GeneralManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    
    }
    void Update()
    {
        debugInputs();
    }
    // debugInputs is a method that checks for debug inputs or debuging purposes
    void debugInputs()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Code to execute when the 'A' button is pressed
            SceneManager.LoadScene("Main Game");
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("Tutorial");
            // Code to execute when the 'B' button is pressed
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("Menu");
            // Code to execute when the 'C' button is pressed
        }
        // Add more if statements for other buttons as needed
    }

}
