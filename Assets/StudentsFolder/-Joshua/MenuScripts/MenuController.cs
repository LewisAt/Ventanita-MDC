using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //Used to start the game when the proper button is pressed
    public void StartBtn()
    {
        //Loads the scene that matches with the scene number referenced in the script
        SceneManager.LoadScene(1);
    }

    //Used to send the player to the starting menu
    public void Back2Menu()
    {
        //Loads the scene that has the same name as the scene referenced in script
        SceneManager.LoadScene("StartingMenuScene");
    }
}
