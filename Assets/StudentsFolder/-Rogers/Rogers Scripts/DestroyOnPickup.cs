using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnPickup : MonoBehaviour
{
    spacePos spaceOccupied;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "spoon")
        {
            spaceOccupied.hasFood = false;
            Destroy(this.gameObject);
        }
    }
    public void AddSpaceOcc(spacePos space)
    {
        spaceOccupied = space;
    }
}
