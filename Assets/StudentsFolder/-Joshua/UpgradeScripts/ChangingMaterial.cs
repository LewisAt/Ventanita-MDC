using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingMaterial : MonoBehaviour
{
    public Material[] material;
    public int x;
    public static int NewMaterial;
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

    void OnAwake ()
    {
        x = NewMaterial;
    }
    // Update is called once per frame
    void Update()
    {
        rend.sharedMaterial = material[x];
        NewMaterial = x;
    }

    public void NextMaterial()
    {
        if (x < 2)
        {
            x++;
            //x = NewMaterial;
        }
        else
        {
            x = 0;
        }
    }
}
