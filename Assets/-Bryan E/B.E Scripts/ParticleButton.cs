using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UI;

public class ParticleButton : MonoBehaviour
{
    public ParticleSystem upgradeParticle;
    public Button upgrade;

    void Start()
    {
        Button btn = upgrade.GetComponent<Button>();
        btn.onClick.AddListener(ParticleStart);
    }

    private void ParticleStart()
    {
        upgradeParticle.Play();
    }
}
