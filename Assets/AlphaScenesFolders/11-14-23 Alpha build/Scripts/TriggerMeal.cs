using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMeal : MonoBehaviour
{
    private GradeOrderInput m_Input;
    private void Start()
    {
        m_Input = GameObject.FindGameObjectWithTag("CustomerWindow").GetComponent<GradeOrderInput>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Customer")
        {
            m_Input.MakeAnOrder();
        }
    }
}
