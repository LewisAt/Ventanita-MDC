using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_GoodBye : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "food")
        {
            Destroy(collision.gameObject);
        }
    }
}
