using UnityEngine;

public class InteractionsUITrigger : MonoBehaviour
{

    public float range = 10f;

    public Camera vrCam;

    // Update is called once per frame
    void Update()
    {
        
    }

    void VRRay()
    {
        RaycastHit hit;
        if(Physics.Raycast(vrCam.transform.position, vrCam.transform.forward, out hit, range));
        {
            Debug.Log(hit.transform.name);
        }
    }
}