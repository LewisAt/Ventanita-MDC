using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private float timeWait = 0;
    public float time = 10;
    private float tipReduce;
    public Slider custSlider;
    public Text tipEarned;
    private float pay = 10;
    public float tip= 5;


    //makes sure that the customer has a rigidbody
    private void Start()
    {
        if (customer == null) customer = GetComponent<Rigidbody>();
        customer.useGravity = false;
        customer.isKinematic = true;

        customerRender.sprite = sideFace;
        sliderTimer();
        timeWait = time;
        custSlider.value = timeWait;
        tipEarned.gameObject.SetActive(false);
        tip = 5;
        pay = 10;
        tipReduce = 0;
    }

    private void FixedUpdate()
    {
        //first direction and turn point for customer
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
        //second direction that brings the customer towards the window and changes their sprite
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
        //condition that makes customer change sprite, leave, and then despawn them and spawn a new customer
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
        //pass condition, timer, and payment
        if (Input.GetKeyDown("space") && check2 == true)
        {
            tipEarned.gameObject.SetActive(true);
            check3 = true;
            tip = tip - tipReduce;
            tip = Mathf.Round(tip * 100.0f) * 0.01f;
            tipEarned.text = "You earned a " + tip.ToString() + "$ tip!";
            pay += tip;
            MoneyTracker.UserCash += pay;
        }

        if(check2 == true && check3 == false)
        {
            timeWait -= Time.deltaTime;
            tipReduce += Time.deltaTime / 2;
            custSlider.value = timeWait;
            if(timeWait <= 0)
            {
                check3 = true;
            }
        }
    }
    void SpawnCustomer()
    {
        Instantiate(realCustomer, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    void sliderTimer()
    {
        custSlider.minValue = 0;
        custSlider.maxValue = time;
        custSlider.wholeNumbers = true;
    }
}
