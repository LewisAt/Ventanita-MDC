using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//this script is attached to the customer sprite and will move the customer to the window and despawn them

public class Movetowindow : MonoBehaviour
{
    private Rigidbody customer;
    public GameObject[] points;
    private CustomerManager customerManager;
    private bool paused = false;
    public bool PauseCustomer
    {
        get { return paused; }
        set {
            Debug.Log("Can you do that here?");
            if(value == false)
            {
                customerManager.activateRandomCustomer();
            }
             paused = value; }
    }
    private Sprite frontFace;
    private Sprite sideFace;
    private float Speed = 4;
    private int i = 0;


    //allows for the movement events to trigger



    //Customer waits for this time then leaves if takes too long - money and tip payed when order complete

    /*
    selected a Customer model
    Movetowards window
    Adjust Customer Model depending on movement
    customer needs to have a stopping waiting while waiting for their food.

    */
    void Awake()
    {
        this.gameObject.SetActive(false);
        customer = GetComponent<Rigidbody>();
        customerManager = GameObject.Find("====GameSystems====/GameFunctions(POSITIONSMATTER)/CustomerManager").GetComponent<CustomerManager>();
    }
    void FixedUpdate()
    {
        if(paused)
        {
            return;
        }
        else
        {
            moveTowardspoint();
        }
    }
    void FaceCustomerTowardsStore()
    {
        
    }
    void handleCustomerFace()
    {

    }
    void moveTowardspoint()
    {
        Vector3 destination = Vector3.MoveTowards(transform.position, points[i].transform.position, Speed * Time.deltaTime);
        transform.position = new Vector3(destination.x, this.transform.position.y, destination.z);
        float distance = DistanceToPoint();
        //the if statement only looks at X value since we only need to match one value to work.
        if( distance < 0.1f && i == points.Length - 1)
        {
            // waits until it reaches the last point then resets the customer
            resetCustomer();
        }

        if( distance < 0.1f && i < points.Length - 1)
        {
            // if the customer gets close enough to the point it will move to the next point
            i++;
        }
        else
        {
            Debug.Log("Current point is " + i );
            Debug.Log(transform.position.x + " " + points[i].transform.position.x);
            Debug.Log("Customer isnt treaching the next point yet");
        }
        

    }
    float DistanceToPoint()
    {
        //gets the current distance to the next point
        return Vector3.Distance(transform.position , new Vector3
        (points[i].transform.position.x, this.transform.position.y, points[i].transform.position.z));
        /// <summary>
        /// we have to set the Y value to the same as the customer so that the distance is accurate
        /// </summary>
        /// <returns></returns>
    }
    void resetCustomer()
    {

        //trigger reset
         i = 0;
         transform.position = new Vector3(points[0].transform.position.x, this.transform.position.y, points[0].transform.position.z);
        this.gameObject.SetActive(false);
    }
}
