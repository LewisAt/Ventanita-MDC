using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Radio : MonoBehaviour
{
    public PlateRequester GameEngine;
    public Text RadioText;
    public bool isStarted = false;
    public AudioSource OurMusic;
    public void StartGame()
    {
        GameEngine.enabled = true;
        OurMusic.enabled = true;

        waitBeforeReset();
        if (isStarted)
        {
            SceneManager.LoadScene("GameScene");
            
        }
        isStarted = true;

    }

    IEnumerator waitBeforeReset()
    {
        yield return new WaitForSeconds(5);
        RadioText.text = "Hit me Again To reset";
    }
}
