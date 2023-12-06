using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandFoodSpawner : MonoBehaviour
{
    int num;
    float randX;
    float randZ;
    public GameObject[] rawFood;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            num = Random.Range(0, 2);
            randX = Random.Range(-2f, 2f);
            randZ = Random.Range(-2f, 2f);
            Vector3 pos = new Vector3(randX, transform.position.y,randZ);
            Instantiate(rawFood[num], pos, Quaternion.identity);
        }
    }
}
