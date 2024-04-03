using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeReset : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject resetGameobject;
    public AnimationCurve ladleRespawnCurve;
    private bool isRespawning = false;
    private float t;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public IEnumerator ResetCoffee()
    {
        yield return new WaitForSeconds(1.5f);
        rb.constraints = RigidbodyConstraints.FreezeAll;
        isRespawning = true;
    }
    private float respawnTime
    {
        get { return t; }
        set { t = Mathf.Clamp(value,0f,1f); }
    }
    void Update()
    {
        if(!isRespawning)
        {
            return;
        }
        respawnTime += Time.deltaTime * 0.5f;
        if(respawnTime >= 1f)
        {
            isRespawning = false;
            respawnTime = 0f;
            rb.constraints = RigidbodyConstraints.None;
        }
        float EvaluatedTime = ladleRespawnCurve.Evaluate(respawnTime);

        this.transform.position = Vector3.Lerp(this.transform.position, resetGameobject.transform.position, EvaluatedTime);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, resetGameobject.transform.rotation, EvaluatedTime);
        
    }
}
