using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LaldleIdentifier : MonoBehaviour
{
    private GameObject LadleBody;
    public AnimationCurve ladleRespawnCurve;
    private NewPoolingMethod SpoonParent;
    private float t;
    public float respawnTime
    {
        get { return t; }
        set { t = Mathf.Clamp(value,0f,1f); }
    }
    private bool isRespawning;
    public Transform spawnPoint;
    Rigidbody parentRB;

    public void Start()
    {
        parentRB = this.transform.parent.GetComponent<Rigidbody>();
        parentRB.isKinematic = false;
        parentRB.constraints = RigidbodyConstraints.FreezeAll;
        LadleBody = this.transform.parent.gameObject;
        SpoonParent = this.GetComponent<NewPoolingMethod>();
    }
    //Identifies the ladle in code. Makes it accessible by other scripts;
    //Was going to be used in case we were gonna have different ladle's for each food object.


    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1.5f);
        //! if the player grabs it before this point end the respawn event;

        parentRB.constraints = RigidbodyConstraints.FreezeAll;
        isRespawning = true;

    }
    public void RespawnNow()
    {
        parentRB.constraints = RigidbodyConstraints.FreezeAll;
        isRespawning = true;
    }
    //^ gross i know but i want it animated
    void Update()
    {
        if(!isRespawning)
        {
            return;
        }
        SpoonParent.ClearCurrentFood();
        respawnTime += Time.deltaTime * 0.5f;
        if(respawnTime >= 1f)
        {
            isRespawning = false;
            respawnTime = 0f;
        }
        float EvaluatedTime = ladleRespawnCurve.Evaluate(respawnTime);

        LadleBody.transform.position = Vector3.Lerp(LadleBody.transform.position, spawnPoint.position, EvaluatedTime);
        LadleBody.transform.rotation = Quaternion.Lerp(LadleBody.transform.rotation, spawnPoint.rotation, EvaluatedTime);
        
    }

    public void FreeWilly()
    {
        //parentRB.isKinematic = true;
        parentRB.constraints = RigidbodyConstraints.None;
    }
}
