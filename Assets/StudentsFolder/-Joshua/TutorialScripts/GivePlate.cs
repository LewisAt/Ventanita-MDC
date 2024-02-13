using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GivePlate : MonoBehaviour
{
    public GameObject customer;
    public GameObject button;

    public void Start()
    {
        button.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "plate")
        {
            Destroy(collision.gameObject);
            Destroy(customer);
            button.SetActive(true);
        }
    }
}
