using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawn : MonoBehaviour
{
    public GameObject spawner;
    public GameObject plate;
    public float spawnTime = 5;
    public bool objIn = false;

    void Start()
    {
        SpawnPoF();
    }
    void SpawnPoF()
    {
        Instantiate(plate, spawner.transform.position, spawner.transform.rotation);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(spawnTime);
        SpawnPoF();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "plate")
        {
            objIn = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "plate")
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
