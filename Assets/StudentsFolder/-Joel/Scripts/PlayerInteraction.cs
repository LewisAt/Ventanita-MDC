using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class PlayerInteraction : MonoBehaviour
{
    XROrigin XROrigin;
    Camera main;
    public LayerMask layersToHit;
    float maxDistance = 100f;
    GameObject objectHit;
    MeshRenderer objectMesh;
    Material PriorMaterial;
    public GameObject PointOFHIt;
    public Material objectShader;
    public GameObject[] interactables;

    // Start is called before the first frame update
    void Start()
    {
        interactables = GameObject.FindGameObjectsWithTag("interactable");
        foreach (GameObject interactable in interactables)
        {
            interactable.layer = 10;
        }

        XROrigin = GetComponent<XROrigin>();
        main = XROrigin.Camera;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(this.transform.position, transform.forward, Color.blue);
        if (Physics.Raycast(main.transform.position, main.transform.forward, out hit, maxDistance, layersToHit))
        {
            PointOFHIt.transform.position = hit.point;
            objectHit = hit.collider.gameObject;
            objectMesh = objectHit.GetComponent<MeshRenderer>();
            if (objectMesh.material != objectShader)
            {
                PriorMaterial = objectMesh.material;
                objectMesh.material = objectShader;
                print("the shader should be working");
            }
        }
        else if (objectHit != null)
        {
            print("else if statement triggered");
            objectMesh.material = PriorMaterial;
            print(objectHit.name);
        }
    }
}
