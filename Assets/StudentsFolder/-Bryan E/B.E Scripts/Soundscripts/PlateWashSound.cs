using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlateWashSound : MonoBehaviour
{
    //goes on plateWashSound object
    public AudioSource washSound;
    private float cooldown = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "plate" && cooldown <= 0)
        {
            washSound.Play();
            cooldown = 2f;
        }
    }
    private void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }
}
