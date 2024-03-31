using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerDialogueController : MonoBehaviour
{
    private AudioSource CustomerImpatient;
    private AudioSource CustomerGreatFul;
    private AudioSource CustomerWTFISTHIS;

    void Start()
    {
        CustomerImpatient = transform.GetChild(0).GetComponent<AudioSource>();
        CustomerGreatFul = transform.GetChild(1).GetComponent<AudioSource>();
        CustomerWTFISTHIS = transform.GetChild(2).GetComponent<AudioSource>();
        GameManager.OrderTookTooLongEvent += triggerCustomerImpatient;
        GameManager.CorrectOrderEvent += triggerCustomerGreatFul;
        GameManager.WrongOrderEvent += triggerCustomerWTFISTHIS;

    }
    bool Delayed = true;
    void OnEnable()
    {
        StartCoroutine(DelayImpatientandGreatful());
    }
    public void triggerCustomerImpatient()
    {
        if(Delayed == true)
        {
            return;
        }
        CustomerImpatient.Play();
        Debug.Log("Customer Impatient triggered");
    }
    public void triggerCustomerGreatFul()
    {
        if(Delayed == true)
        {
            return;
        }
        CustomerGreatFul.Play();
        Debug.Log("Customer Greatful triggered");
    }
    public void triggerCustomerWTFISTHIS()
    {
        CustomerWTFISTHIS.Play();
        Debug.Log("Customer WTFISTHIS triggered");
    }
    IEnumerator DelayImpatientandGreatful()
    {
        yield return new WaitForSeconds(1.5f);
        Delayed = false;
    }



}
