using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingMaterial : MonoBehaviour
{
    public Material[] material;
    public int x;
    public static int newMaterial;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
        OnAwake();
    }

    void OnAwake()
    {
        x = newMaterial;
        //newMaterial = x;

    }

    // Update is called once per frame
    void Update()
    {
        rend.sharedMaterial = material[x];
        //newMaterial = x;
        newMaterial = x;
    }

    public void NextMaterial()
    {
        if (x < 2)
        {
            x++;
            //newMaterial = x;
        }
        else
        {
            x = 0;
        }
    }
}
