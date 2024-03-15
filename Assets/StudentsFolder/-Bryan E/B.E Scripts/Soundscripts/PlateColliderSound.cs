using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlateColliderSound : MonoBehaviour
{
    public AudioSource PlatehitSound;
    private float cooldown = 1f;

    private void Start()
    {
        PlatehitSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (cooldown <= 0f)
        {
            PlatehitSound.Play();
            cooldown = 0.5f;
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
