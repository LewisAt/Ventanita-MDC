using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void Back2Menu()
    {
        SceneManager.LoadScene("StartingMenuScene");
    }
}
