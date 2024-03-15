using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlateSpawn : MonoBehaviour
{
    //public GameObject spawner;
    public GameObject plate;
    public AudioSource plateSound;
    private GameObject spawnPlate;
    public float spawnTime = 5;
    public bool objIn = false;
    public GameObject player;
    private XROrigin xrOrigin;
    private XRController playerController;

    void Start()
    {
        //xrOrigin = player.GetComponent<XROrigin>();
        //playerController = player.GetComponentInChildren<XRController>();
    }
    public void SpawnPoF()
    {
        print("debug works");
        
    }

    public void SpawnObject()
    {
        plateSound.Play();
        spawnPlate = Instantiate(plate, transform.position, transform.rotation);
        XRGrabInteractable xRGrabInteractable = spawnPlate.GetComponent<XRGrabInteractable>();
        if (xRGrabInteractable != null)
        {
            xRGrabInteractable.transform.position = transform.position;
            xRGrabInteractable.transform.rotation = transform.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
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
