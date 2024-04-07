using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMealRequest : MonoBehaviour
{
    private GradeOrderInput m_Input;
    private bool m_CustomerArrived = false;
    public AudioSource Arrival;
    private Movetowindow m_Customer;

    private void Start()
    {
        m_Input = GameObject.FindGameObjectWithTag("CustomerWindow").GetComponent<GradeOrderInput>();
    }
    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("Customer Arrived");
            Debug.Log("the delay on the window is " + m_Input.WindowResetDelay);
        if (other.tag == "Customer" && !m_CustomerArrived && m_Input.WindowResetDelay == false)
        {
            m_CustomerArrived = true;
            m_Customer = other.GetComponent<Movetowindow>();
            Invoke("PauseCustomer", 0.1f);
            //pause the customer
            


            m_Input.MakeAnOrder();
            Arrival.Play();
        }
    }
    public void PauseCustomer()
    {
            m_Customer.PauseCustomer = true;
            m_Input.triggerMeal = this;
    }
    public void UnpauseCustomer()
    {
            m_CustomerArrived = false;
            m_Customer.PauseCustomer = false;
            m_Customer.FixForCustomerNotSpawning();
            Debug.Log("Unpausing Customer");
    }
}
