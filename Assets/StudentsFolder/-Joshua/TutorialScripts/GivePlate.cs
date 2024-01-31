using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePlate : MonoBehaviour
{
    public GameObject customer;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "plate")
        {
            Destroy(collision.gameObject);
            Destroy(customer);
        }
    }
}
