using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaldleIdentifier : MonoBehaviour
{
    public GameObject LegalParent;
    public GameObject LegalSibling;
    Vector3 spawnPoint;
    Quaternion spawnRotation;
    Rigidbody parentRB;
    MeshRenderer parentMesh;

    public void Start()
    {
        spawnPoint = LegalParent.transform.position;
        spawnRotation = LegalParent.transform.rotation;
        parentRB = LegalParent.GetComponent<Rigidbody>();
        parentMesh = LegalParent.GetComponent<MeshRenderer>();
        parentRB.isKinematic = false;
        parentRB.constraints = RigidbodyConstraints.FreezeAll;
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

    public IEnumerator Respawn()
    {
        parentMesh.enabled = false;
        yield return new WaitForSeconds(2f);
        LegalParent.transform.SetPositionAndRotation(spawnPoint, spawnRotation);
        parentRB.isKinematic = false;
        parentRB.constraints = RigidbodyConstraints.FreezeAll;
        parentMesh.enabled = true;
    }

    public void FreeWilly()
    {
        //parentRB.isKinematic = true;
        parentRB.constraints = RigidbodyConstraints.None;
    }
}
