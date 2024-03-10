using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMeal : MonoBehaviour
{
    private GradeOrderInput m_Input;
    public AudioSource Arrival;
    private Movetowindow m_Customer;

    private void Start()
    {
        m_Input = GameObject.FindGameObjectWithTag("CustomerWindow").GetComponent<GradeOrderInput>();
        m_Input.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Customer")
        {
            m_Customer = other.GetComponent<Movetowindow>();
            PauseCustomer();
            //pause the customer
            


            Debug.Log("Customer Arrived");
            m_Input.enabled = true;
            m_Input.MakeAnOrder();
            Arrival.Play();
        }
    }
    public void PauseCustomer()
    {
            m_Customer.PauseCustomer = true;
            m_Input.MealTrigger = this;
    }
    public void UnpauseCustomer()
    {
            m_Customer.PauseCustomer = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Customer")
        {
            m_Input.enabled = false;
        }
    }
}