using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Same as the Randomizer Script, but will be placed on Joel's Plate Interaction script.
public class Prefab_Change : MonoBehaviour
{
    public GameObject square;
    public GameObject circlePrefab;

    void Start()
    {
        Change_Prefab();
    }

    void Change_Prefab()
    {
        GameObject newCircle = Instantiate(circlePrefab, square.transform.position, square.transform.rotation);

        Destroy(square);
    }
}
