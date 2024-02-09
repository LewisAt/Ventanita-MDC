using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSFX : MonoBehaviour
{
    public AudioSource sourcePickup;
    public AudioSource sourceDropdown;
    public AudioClip clipUp;
    public AudioClip clipDown;

    // Start is called before the first frame update
    public void PlayPickupSFX()
    {
        sourcePickup.PlayOneShot(clipUp);
    }

    public void PlayDropDownSFX()
    {
        sourceDropdown.PlayOneShot(clipDown);
    }
}