using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSystem : MonoBehaviour
{
    //we want stations so make switching possible by just muting which one is not needed
    [SerializeField] private AudioSource Radio;
    [SerializeField] private AudioClip RadioIntro;
    [SerializeField] private AudioClip RadioLoop;
    [SerializeField] private AudioClip RadioOutro;
    public AudioClip radioOutroCheck
    {
        get
        {
            return RadioOutro;
        }
    }

    /* void Update()
    {
        if(GameManager.instance.isGameRunning == false)
        {
            Radio.Stop();
            return;
        }
        if(!Radio.isPlaying)
        {
            playLoop();
        }
    }
    void playIntro()
    {
        Radio.clip = RadioIntro;
        Radio.Play();
    }
    void playLoop()
    {
        Radio.clip = RadioLoop;
        Radio.loop = true;
        Radio.Play();
    }
    
    public void PlayEnding()
    {
        Radio.clip = RadioOutro;
        Radio.Play();
    } */

}
