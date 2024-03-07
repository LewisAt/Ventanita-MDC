using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimpeCreditsplayer : MonoBehaviour
{
    public Image Background;
    public Sprite Image1;
    public Sprite Image2;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        Background.sprite = Image1;
        StartCoroutine(NextPanel());
    }

    IEnumerator NextPanel()
    {
        yield return new WaitForSeconds(15);
        Background.sprite = Image2;
        StartCoroutine(loadMainGame());
    }
    IEnumerator loadMainGame()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(0);
    }
}
