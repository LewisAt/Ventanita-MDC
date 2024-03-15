using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadleColSound : MonoBehaviour
{
    //goes on ladle object that has a collider
    public AudioSource LadleSound;
    private float cooldown = 0.4f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "food" && cooldown <= 0)
        {
            LadleSound.Play();
            cooldown = 0.4f;
        }
    }

    private void Update()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }
}
