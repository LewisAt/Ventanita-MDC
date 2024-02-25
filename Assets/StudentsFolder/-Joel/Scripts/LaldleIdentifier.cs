using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaldleIdentifier : MonoBehaviour
{
    public GameObject LegalParent;
    Vector3 spawnPoint;
    Quaternion spawnRotation;
    public void Start()
    {
        spawnPoint = LegalParent.transform.position;
        spawnRotation = LegalParent.transform.rotation;
        print(spawnPoint);
    }
    //Identifies the ladle in code. Makes it accessible by other scripts;
    //Was going to be used in case we were gonna have different ladle's for each food object.
    public enum TypeOfLaldle
    {
        general,
        tostone,
        croqueta,
        maduro,
        Fricase,
        Rabo,
        Beans,
        Arroz
    }

    public TypeOfLaldle typeOfLaldle;

    public void Respawn()
    {
        print("function call");
        LegalParent.transform.position = spawnPoint;
        LegalParent.transform.rotation = spawnRotation;
    }
}
