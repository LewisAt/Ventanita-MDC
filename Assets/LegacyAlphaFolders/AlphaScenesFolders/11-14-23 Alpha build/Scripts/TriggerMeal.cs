using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMeal : MonoBehaviour
{
    private GradeOrderInput m_Input;
    public AudioSource Arrival;
    private void Start()
    {
        m_Input = GameObject.FindGameObjectWithTag("CustomerWindow").GetComponent<GradeOrderInput>();
        m_Input.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Customer")
        {
            Debug.Log("Customer Arrived");
            m_Input.enabled = true;
            m_Input.MakeAnOrder();
            Arrival.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Customer")
        {
            m_Input.enabled = false;
        }
    }
}