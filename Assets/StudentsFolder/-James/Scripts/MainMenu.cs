using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void returnMainMenu()
    {
        SceneManager.LoadScene("Menu 3");
    }
}
