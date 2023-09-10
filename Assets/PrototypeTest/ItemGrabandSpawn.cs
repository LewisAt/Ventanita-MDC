using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrabandSpawn : MonoBehaviour
{
    public GameObject itself;
    public Transform spawnPoint;
    public bool isPlate;
    public float Delay = 1f;
    private void OnTriggerExit(Collider other)
    {

        if (other.tag != "Food" && !isPlate)
        {
            return;
        }
        if (other.gameObject != itself)
        {
            return;
        }
        GameObject clone = Instantiate(itself);
        Rigidbody CloneRB = clone.GetComponent<Rigidbody>();
        CloneRB.isKinematic = false;
        CloneRB.useGravity = true;
        itself = clone;

        clone.transform.position = spawnPoint.transform.position;
    }

}

    
       

