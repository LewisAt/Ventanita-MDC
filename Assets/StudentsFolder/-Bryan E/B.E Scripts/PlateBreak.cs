using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBreak : MonoBehaviour
{
    public ParticleSystem platebreak;
    public MeshRenderer myAppearance;

    private void Start()
    {
        platebreak = GetComponent<ParticleSystem>();
        myAppearance = GetComponentInChildren<MeshRenderer>();
    }

    public IEnumerator startBreak()
    {
        myAppearance.enabled = false;
        platebreak.Play();
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
