using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTutorial : MonoBehaviour
{
    // text stuff
    public TMP_Text tutorialText;
    public string[] getTutorialText;
    public int current;
    //currentMax is basically how long the array is
    public int currentMax = 4;

    //timer
    public float targetTime = 0.0f;

    void Start()
    {
        //set value to 0 to prevent bugs
        current = 0;
    }

    void Update()
    {
        //set the TMPro text to the string
        tutorialText.SetText(getTutorialText[current]);

        //debug
        if (Input.GetKeyDown(KeyCode.Space) && current < currentMax) {
            current++;
        }

        //timer
        targetTime += Time.deltaTime;

        if (targetTime == 10) {
            //play voiceline OR display text
        }
    }
}
