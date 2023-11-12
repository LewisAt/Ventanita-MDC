using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupSpawn : MonoBehaviour
{
    public GameObject spawner;
    public GameObject cup;
    public float spawnTime = 5;
    public bool objIn = false;

    void Start()
    {
        SpawnPoF();
    }
    void SpawnPoF()
    {
        Instantiate(cup, spawner.transform.position, spawner.transform.rotation);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(spawnTime);
        SpawnPoF();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Cup")
        {
            objIn = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Cup")
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
