using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public GameObject spawner;
    public GameObject food;
    public float spawnTime = 5;
    public bool objIn = false;

    void Start()
    {
        SpawnPoF();
    }
    void SpawnPoF()
    {
        Instantiate(food, spawner.transform.position, spawner.transform.rotation);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(spawnTime);
        SpawnPoF();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Food")
        {
            objIn = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Food")
        {
            objIn = false;
        }
    }
    void Update()
    {
        if (objIn == false)
        {
            StartCoroutine(Wait());
            objIn = true;
        }
    }
}
