using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerDialogueController : MonoBehaviour
{
    private AudioSource CustomerImpatient;
    private AudioSource CustomerGreatFul;
    private AudioSource CustomerWTFISTHIS;
    private bool AudioEventTriggered = false;

    void Start()
    {
        CustomerImpatient = transform.GetChild(0).GetComponent<AudioSource>();
        CustomerGreatFul = transform.GetChild(1).GetComponent<AudioSource>();
        CustomerWTFISTHIS = transform.GetChild(2).GetComponent<AudioSource>();
        GameManager.OrderTookTooLongEvent += triggerCustomerImpatient;
        GameManager.CorrectOrderEvent += triggerCustomerGreatFul;
        GameManager.WrongOrderEvent += triggerCustomerWTFISTHIS;

    }
    private void audioEventTriggered()
    {
        AudioEventTriggered = true;
    }
    bool Delayed = true;
    void OnEnable()
    {
        AudioEventTriggered = false;
        StartCoroutine(DelayImpatientandGreatful());
    }
    public void triggerCustomerImpatient()
    {
        if(AudioEventTriggered == true)
        {
            return;
        }
        if(Delayed == true)
        {
            return;
        }
        audioEventTriggered();
        CustomerImpatient.Play();
        Debug.Log("Customer Impatient triggered");
    }
    public void triggerCustomerGreatFul()
    {
        if(AudioEventTriggered == true)
        {
            return;
        }
        if(Delayed == true)
        {
            return;
        }
        audioEventTriggered();

        CustomerGreatFul.Play();
        Debug.Log("Customer Greatful triggered");
    }
    public void triggerCustomerWTFISTHIS()
    {
        if(AudioEventTriggered == true)
        {
            return;
        }
        CustomerWTFISTHIS.Play();
        Debug.Log("Customer WTFISTHIS triggered");
    }
    IEnumerator DelayImpatientandGreatful()
    {
        yield return new WaitForSeconds(1.5f);
        Delayed = false;
    }



}
