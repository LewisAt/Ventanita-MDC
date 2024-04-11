using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBounce : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition;
    bool isEnabledAtStart = false;
    void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z);
        if(isEnabledAtStart)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.PingPong(Time.time, 1));
    }
}
