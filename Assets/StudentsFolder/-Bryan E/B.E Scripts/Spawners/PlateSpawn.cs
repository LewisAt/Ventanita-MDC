using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateSpawn : MonoBehaviour
{
    public GameObject spawner;
    public GameObject plate;
    public float spawnTime = 5;
    public bool objIn = false;
    private bool waitP = false;

    void Start()
    {

    }
    public void SpawnPoF()
    {
        print("debug works");
        Instantiate(plate, new Vector3(10,10,10), spawner.transform.rotation);
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpawnPoF();
        }
    }




    /*IEnumerator Wait()
    {
        waitP = true;
        yield return new WaitForSeconds(spawnTime);
        SpawnPoF();
        waitP = false;
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
        if (col.gameObject.tag == "plate" && waitP == false)
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
    }*/

    /*This script was modified by Joel Figueroa to complete task "fix plate spawning"*/
}
