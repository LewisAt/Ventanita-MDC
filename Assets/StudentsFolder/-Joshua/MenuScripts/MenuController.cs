using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public int sceneNumber = 0;
    //Used to start the game when the proper button is pressed
    public void StartBtn()
    {
        //Loads the scene that matches with the scene number referenced in the script
        SceneManager.LoadScene(sceneNumber);
    }

    //Used to send the player to the starting menu
    public void Back2Menu()
    {
        //Loads the scene that has the same name as the scene referenced in script
        SceneManager.LoadScene("StartingMenuScene");
    }

    //Used to skip to the Main Scene
    public void Skiptutorial()
    {
        // Skips the tutorial once the button is pressed
        SceneManager.LoadScene("MainBuil 11-25-23");
    }
}
