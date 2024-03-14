using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Movetowindow : MonoBehaviour
{
    //customer id
    public int CustId = 0;
    public static int sameId = 0;
    public int showid;

    //where customer will stop and turn, change sprite, or despawn
    public GameObject firstPoint;
    public GameObject secondPoint;
    public GameObject thirdPoint;
    public GameObject fourthPoint;

    public GameObject linePoint1;
    public GameObject linePoint2;
    public GameObject linePoint3;
    public GameObject linePoint4;

    //customer, sprites, speed, and respawn point
    public GameObject realCustomer;
    public GameObject spawnPoint;
    public Rigidbody customer;
    public SpriteRenderer customerRender;
    public Sprite[] CustomerFaces;
    float SpriteChoose = 0;
    public Sprite frontFace;
    public Sprite sideFace;
    public float Speed = 0.5f;

    //allows for the movement events to trigger
    private bool spotcheck = false;
    private bool check = false;
    private bool check2 = false;
    private bool check3 = false;
    private bool check4 = false;

    private bool exCheck = true;
    private bool spawnCheck = true;

    //Customer waits for this time then leaves if takes too long - money and tip payed when order complete
    float tipReduce = 0.3f;
    public float tip = 5;
    public TMP_Text tipText;

    //audio for when order is completed or failed
    public AudioSource completeSound;
    public AudioSource failSound;


    //makes sure that the customer has the correct rigidbody and settings
    private void Start()
    {
        GameObject.FindGameObjectWithTag("CustomerWindow").GetComponent<GradeOrderInput>().addCustomer(this);
        CustomerRandomizer();
        if (customer == null) customer = GetComponent<Rigidbody>();
        customer.useGravity = false;
        customer.isKinematic = true;

        Speed = 0.5f;
        customerRender.sprite = sideFace;
        tip = 5;
        tipText.enabled = false;
        CustId += 1;
        if (CustId > 2)
        {
            CustId = 2;
        }
    }

    private void FixedUpdate()
    {
        if (spotcheck == false)
        {
            if (linePoint1.GetComponent<CustomerLine>().spot1 == false && check == false && CustId == 1)
            {
                spotcheck = true;
                CustId -= 1;
                sameId = CustId;
                GameObject.FindGameObjectWithTag("CustomerWindow").GetComponent<GradeOrderInput>().addCustomer(this);
            }
            else if (linePoint1.GetComponent<CustomerLine>().spot1 == true && linePoint2.GetComponent<CustomerLine>().spot2 == false)
            {
                if (exCheck == true && CustId >= 2)
                {
                    CustId -= 1;
                    exCheck = false;
                }
                float delta = linePoint2.transform.position.z - transform.position.z;

                customer.MovePosition(new Vector3(
                    transform.position.x,
                    transform.position.y,
                    transform.position.z + delta * Speed * Time.deltaTime));
                if (customer.transform.position.z >= linePoint2.transform.position.z - 2f)
                {

                    if (linePoint1.GetComponent<CustomerLine>().spot1 == false)
                    {
                        spotcheck = true;
                        CustId -= 1;
                        sameId = CustId;
                        exCheck = true;
                        GameObject.FindGameObjectWithTag("CustomerWindow").GetComponent<GradeOrderInput>().addCustomer(this);
                    }
                }
            }
            else if (linePoint1.GetComponent<CustomerLine>().spot1 == true && linePoint2.GetComponent<CustomerLine>().spot2 == true &&
                linePoint3.GetComponent<CustomerLine>().spot3 == false && CustId == 2)
            {
                float delta = linePoint3.transform.position.z - transform.position.z;

                customer.MovePosition(new Vector3(
                    transform.position.x,
                    transform.position.y,
                    transform.position.z + delta * Speed * Time.deltaTime));
                if (customer.transform.position.z >= linePoint3.transform.position.z - 2f)
                {
                    if (linePoint1.GetComponent<CustomerLine>().spot1 == true && linePoint2.GetComponent<CustomerLine>().spot2 == false)
                    {
                        CustId -= 1;
                        sameId = CustId;
                        GameObject.FindGameObjectWithTag("CustomerWindow").GetComponent<GradeOrderInput>().addCustomer(this);
                    }
                }
            }
        }
        //first direction brings toward center of path and changes sprite
        if (check == false && spotcheck == true)
        {
            float delta = firstPoint.transform.position.z - transform.position.z;

            customer.MovePosition(new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z + delta * Speed * Time.deltaTime));
            if (customer.transform.position.z >= firstPoint.transform.position.z - 2f)
            {
                check = true;
                customerRender.sprite = frontFace;
            }
        }
        //second direction that brings the customer towards the window
        if (check == true && check2 == false)
        {
            float delta = secondPoint.transform.position.x - transform.position.x;

            customer.MovePosition(new Vector3(
                transform.position.x + delta * Speed * Time.deltaTime,
                transform.position.y,
                transform.position.z));
            if (customer.transform.position.x <= secondPoint.transform.position.x + .5f)
            {
                this.transform.position = new Vector3(customer.transform.position.x, customer.transform.position.y, customer.transform.position.z + 0.3f);
                check2 = true;
                /*
                spawnCheck = true;
                if (spawnCheck == true)
                {
                    Debug.Log("A new customer has arrived!");
                    SpawnCustomer();
                    spawnCheck = false;
                }
                */
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
        if (check4 == true)
        {
            Speed = 0.35f;
            float delta = fourthPoint.transform.position.z - transform.position.z;

            customer.MovePosition(new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z + delta * Speed * Time.deltaTime));
            if (customer.transform.position.z >= fourthPoint.transform.position.z - 1.7f)
            {
                Destroy(realCustomer);
            }
        }

        //Spawn Customers
        if (linePoint3.GetComponent<CustomerLine>().spot3 == false && linePoint2.GetComponent<CustomerLine>().spot2 == false &&
            linePoint1.GetComponent<CustomerLine>().spot1 == true && spawnCheck == true && CustId == 0)
        {
            StartCoroutine(SpawnStart());
            spawnCheck = false;
        }
        
        else if (linePoint3.GetComponent<CustomerLine>().spot3 == false && linePoint2.GetComponent<CustomerLine>().spot2 == true &&
            linePoint1.GetComponent<CustomerLine>().spot1 == true && spawnCheck == true && CustId == 1)
        {
            StartCoroutine(SpawnStart());
            spawnCheck = false;
        }
        
        /*else if (linePoint3.GetComponent<CustomerLine>().spot3 == false && linePoint2.GetComponent<CustomerLine>().spot2 == false &&
            linePoint1.GetComponent<CustomerLine>().spot1 == false && linePoint4.GetComponent<CustomerLine>().spot4 == false)
        {
            StartCoroutine(SpawnWhenEmpty());
        }*/

    }
    private void Update()
    {
        //tip that changes depending on how fast the customer order was finished
        if (check2 == true && check3 == false)
        {
            tipReduce -= 0.01f * Time.deltaTime;
            tip = CustomerOrder.foodsCostForCustomer * tipReduce;
        }

        if (CustId == 1)
        {
            sameId = 1;
        }
        else if (CustId == 2)
        {
            sameId = 1;
        }
        else if (CustId == 0)
        {
            sameId = 1;
        }
        showid = sameId;
    }

    //spawns a new customer at the spawn point
    void SpawnCustomer()
    {
        if (linePoint3.GetComponent<CustomerLine>().spot3 == false && linePoint2.GetComponent<CustomerLine>().spot2 == false &&
            linePoint1.GetComponent<CustomerLine>().spot1 == true && CustId == 0 /*|| linePoint3.GetComponent<CustomerLine>().spot3 == false && linePoint2.GetComponent<CustomerLine>().spot2 == true &&
         linePoint1.GetComponent<CustomerLine>().spot1 == true && CustId == 1*/)
        {
            Instantiate(realCustomer, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        spawnCheck = true;
    }

    /*IEnumerator SpawnWhenEmpty()
    {
        yield return new WaitForSeconds(1f);
        if (linePoint3.GetComponent<CustomerLine>().spot3 == false && linePoint2.GetComponent<CustomerLine>().spot2 == false &&
            linePoint1.GetComponent<CustomerLine>().spot1 == false && linePoint4.GetComponent<CustomerLine>().spot4 == false)
        {
            Instantiate(realCustomer, spawnPoint.transform.position, spawnPoint.transform.rotation);
            yield return new WaitForSeconds(3f);
        }
    }*/
    IEnumerator SpawnStart()
    {
        yield return new WaitForSeconds(7f);
        SpawnCustomer();
    }

    //when customer order complete gives player a sound notification, money, and tip.
    public void CompleteCustomerCorrect()
    {
        completeSound.Play();
        check3 = true;
        tip = Mathf.Round(tip * 100.0f) * 0.01f;
        MoneyTracker.UserCash += CustomerOrder.foodsCostForCustomer + tip;
        tipText.enabled = true;
        tipText.text = "You earned a $" + tip.ToString() + " tip";
    }

    //if player runs out of time a fail sound will play
    public void CompleteCustomerTimeRanOut()
    {
        failSound.Play();
        check3 = true;
    }

    //randomizes the customers sprites
    void CustomerRandomizer()
    {
        SpriteChoose = Random.Range(0, 4);

        //hector
        if (SpriteChoose == 0)
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
