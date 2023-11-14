using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float SpinSpeed = 10f;
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * SpinSpeed, 0);
    }
}
