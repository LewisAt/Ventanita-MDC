using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;

public class PlayerInteraction : MonoBehaviour
{
    XROrigin XROrigin;
    Camera main;
    public LayerMask layersToHit;
    float maxDistance = 100f;
    GameObject objectHit;
    MeshRenderer objectMesh;
    Color hitColor = Color.yellow;
    Color noHitColor;

    // Start is called before the first frame update
    void Start()
    {
        XROrigin = GetComponent<XROrigin>();
        main = XROrigin.Camera;
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(main.transform.position, main.transform.forward, out hit, maxDistance, layersToHit))
        {
            objectHit = hit.collider.gameObject;
            objectMesh = objectHit.GetComponent<MeshRenderer>();
            if (objectMesh.material.color != Color.yellow)
            {
                noHitColor = objectMesh.material.color;
                objectMesh.material.color = hitColor;
                //print("object hit: " + objectHit.name + " object's color: " + noHitColor.ToString());
            }
        }
        else if (objectHit != null)
        {
            objectMesh.material.color = noHitColor;
            //print(objectHit.name);
        }
    }
}

