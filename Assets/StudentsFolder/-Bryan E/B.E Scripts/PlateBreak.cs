using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBreak : MonoBehaviour
{
    public ParticleSystem platebreak;
    public MeshRenderer myAppearance;
    public Rigidbody stopplate;

    private void Start()
    {
        platebreak = GetComponent<ParticleSystem>();
        stopplate = GetComponent<Rigidbody>();
        myAppearance = GetComponentInChildren<MeshRenderer>();
    }

    public IEnumerator startBreak()
    {
        myAppearance.enabled = false;
        platebreak.Play();
        stopplate.mass = 0f;
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
        
    }
}
