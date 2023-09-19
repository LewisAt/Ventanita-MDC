using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSFX : MonoBehaviour
{
    // public AudioSource needs to be declared for every character
    //public AudioSource playSound;
    public AudioSource Mic;
    public AudioSource secondMic;
    bool voiceActive = false;
    //public AudioClip music;
    //public AudioClip punch;
    void OnTriggerExit(Collider other)
    {
        if (voiceActive == false)
        {
            //prevents triggers from other colliders
            if (other.tag == "Customer")
            {
                if (other.gameObject.name == "Cube")
                {
                    Mic.Play();
                    StartCoroutine("waitForSound");
                }
                else
                {
                    secondMic.Play();
                    StartCoroutine("waitForSound");
                }
                    //plays audio source attached to character
                    //playSound.Play();
                    //Mic.PlayOneShot(music);
                    
            }
            
        }
    }
    IEnumerator waitForSound()
    {
        voiceActive = true;
        while(Mic.isPlaying)
        {
            yield return null;
        }
        voiceActive = false;
    }
}
