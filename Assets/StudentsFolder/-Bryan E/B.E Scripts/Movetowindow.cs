using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Movetowindow : MonoBehaviour
{
    //where customer will stop and turn, change sprite, or despawn
    public GameObject firstPoint;
    public GameObject secondPoint;
    public GameObject thirdPoint;
    public GameObject fourthPoint;

    //customer, sprite, speed, and respawn point
    public GameObject realCustomer;
    public GameObject spawnPoint;
    public Rigidbody customer;
    public SpriteRenderer customerRender;
    public Sprite[] CustomerFaces;
    float SpriteChoose = 0;
    public Sprite frontFace;
    public Sprite sideFace;
    public float Speed = 1;

    //allows for the movement events to trigger
    private bool check = false;
    private bool check2= false;
    private bool check3= false;
    private bool check4= false;
    private bool spawnCheck = false;

    //Customer waits for this time then leaves if takes too long - money and tip payed when order complete
    float tipReduce = 0.4f;
    public float tip = 5;
    public TMP_Text tiptext;


    //makes sure that the customer has a rigidbody
    private void Start()
    {
        GameObject.FindGameObjectWithTag("CustomerWindow").GetComponent<GradeOrderInput>().addCustomer(this);
        CustomerRandomizer();
        if (customer == null) customer = GetComponent<Rigidbody>();
        customer.useGravity = false;
        customer.isKinematic = true;

        customerRender.sprite = sideFace;
        tip = 5;
        tipReduce = 0.4f;
        tiptext.enabled = false;
    }

    private void FixedUpdate()
    {
        //first direction brings toward center of path and changes sprite
        if(check == false)
        {
            float delta = firstPoint.transform.position.z - transform.position.z;

            customer.MovePosition(new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z + delta * Speed * Time.deltaTime));
            if (customer.transform.position.z >= firstPoint.transform.position.z - 1.7f)
            {
                //customer.transform.Rotate(0.0f, -90.0f, 0);
                check = true;
                customerRender.sprite = frontFace;
            }
        }
        //second direction that brings the customer towards the window
        if(check == true && check2 == false)
        {
            float delta = secondPoint.transform.position.x - transform.position.x;

            customer.MovePosition(new Vector3(
                transform.position.x + delta * Speed * Time.deltaTime,
                transform.position.y,
                transform.position.z));
            if (customer.transform.position.x <= secondPoint.transform.position.x + .5f)
            {
                check2 = true;
            }
        }
        //third direction that makes customer change sprite then move to despawn point
        if (check3 == true && check4 == false)
        {

            float delta = thirdPoint.transform.position.x - transform.position.x;

            customer.MovePosition(new Vector3(
                transform.position.x + delta * Speed * Time.deltaTime,
                transform.position.y,
                transform.position.z));
            if (customer.transform.position.x >= thirdPoint.transform.position.x - 1f)
            {
                check4 = true;
                customerRender.sprite = sideFace;
            }
        }
        //fourth direction that makes the customer move offscreen, despawn, and spawn new customer
        if(check4 == true)
        {
            float delta = fourthPoint.transform.position.z - transform.position.z;

            customer.MovePosition(new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z + delta * Speed * Time.deltaTime));
            if (customer.transform.position.z >= fourthPoint.transform.position.z - 1.7f)
            {
                spawnCheck = true;
                if (spawnCheck == true)
                {
                    Debug.Log("A new customer has arrived!");
                    SpawnCustomer();
                    spawnCheck = false;
                }
                Destroy(realCustomer);
            }
        }
    }
    private void Update()
    {
        if (check2 == true && check3 == false)
        {
            tipReduce -= 0.0133f * Time.deltaTime;
            tip = CustomerOrder.foodsCostForCustomer * tipReduce;
        }
        
        /*
         // For testing purposes
        if(Input.GetKeyDown("space"))
        {
            CompleteCustomerCorrect();
        }
        */

    }
    void SpawnCustomer()
    {
        Instantiate(realCustomer, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
    public void CompleteCustomerCorrect()
    {
        check3 = true;
        tip = Mathf.Round(tip * 100.0f) * 0.01f;
        MoneyTracker.UserCash += CustomerOrder.foodsCostForCustomer + tip;
        Debug.Log("You earned this tip $" + tip);
        tiptext.enabled = true;
        tiptext.text = "You earned a $" + tip.ToString() + " tip";

    }

    public void CompleteCustomerTimeRanOut()
    {
        check3 = true;
    }

    void CustomerRandomizer()
    {
        SpriteChoose = Random.Range(0, 4);

        //hector
        if(SpriteChoose == 0)
        {
            frontFace = CustomerFaces[0];
            sideFace = CustomerFaces[1];
            this.transform.position = new Vector3(this.transform.position.x, 0.99f, this.transform.position.z);
        }
        //abuela
        else if (SpriteChoose == 1)
        {
            frontFace = CustomerFaces[2];
            sideFace = CustomerFaces[3];
            this.transform.position = new Vector3(this.transform.position.x, 0.71f, this.transform.position.z);
        }
        //kid
        else if (SpriteChoose == 2)
        {
            frontFace = CustomerFaces[4];
            sideFace = CustomerFaces[5];
            this.transform.position = new Vector3(this.transform.position.x, 0.71f, this.transform.position.z);
        }
        //tourist
        else if (SpriteChoose == 3)
        {
            frontFace = CustomerFaces[6];
            sideFace = CustomerFaces[7];
            this.transform.position = new Vector3(this.transform.position.x, 0.99f, this.transform.position.z);
        }
    }


}
