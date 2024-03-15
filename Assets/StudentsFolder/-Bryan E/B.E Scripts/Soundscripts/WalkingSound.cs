using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{
    public AudioSource walk1;
    public AudioSource walk2;
    // set as xr origin
    public GameObject Vrplayer;

    private bool step1 = true;
    private bool step2 = false;
    private bool setPos = true;

    private float cooldown = 0f;
    public Vector3 Playerpos;

    private void Update()
    {
        if (setPos == true)
        {
            Playerpos = new Vector3(0 + Vrplayer.transform.position.x, 0 + Vrplayer.transform.position.y, 0 + Vrplayer.transform.position.z);
            setPos = false;
        }

        if (Playerpos.x != Vrplayer.transform.position.x || Playerpos.z != Vrplayer.transform.position.z)
        {
            if(step1 == true && cooldown <= 0)
            {
                walk1.Play();
                cooldown = 0.4f;
                step1 = false;
                step2 = true;
            }
            else if (step2 == true && cooldown <= 0)
            {
                walk2.Play();
                cooldown = 0.4f;
                step2 = false;
                step1 = true;
            }
            setPos = true;
        }

        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }
}
