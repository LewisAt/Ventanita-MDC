using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UI;

public class ParticleButton : MonoBehaviour
{
    public ParticleSystem upgradeParticle;

    //plays the particle system
    public void ParticleStart()
    {
        upgradeParticle.Play();
    }
}
