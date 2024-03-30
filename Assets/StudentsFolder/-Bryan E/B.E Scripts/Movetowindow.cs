using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
//this script is attached to the customer sprite and will move the customer to the window and despawn them

public class Movetowindow : MonoBehaviour
{
    public GameObject[] points;
    private CustomerManager customerManager;
    private bool paused = false;
    public bool PauseCustomer
    {
        get { return paused; }
        set {
            if(value == false)
            {
                customerManager.activateRandomCustomer();
            }
             paused = value; }
    }
    [SerializeField] private Sprite frontFace;
    [SerializeField] private Sprite sideFace;
    private GameObject player = null;
    private SpriteRenderer spriterenderer;
    private float Speed = 4;
    private int i = 0;
    void OnEnable()
    {
        // Debug.Log(gameObject.name +  " You fuck u bitch why u wake me");
    }


    //allows for the movement events to trigger



    //Customer waits for this time then leaves if takes too long - money and tip payed when order complete

    /*
    selected a Customer model
    Movetowards window
    Adjust Customer Model depending on movement
    customer needs to have a stopping waiting while waiting for their food.

    */
    void  Awake()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        this.gameObject.SetActive(false);
        customerManager = GameObject.Find("====GameSystems====/GameFunctions(POSITIONSMATTER)/CustomerManager1").GetComponent<CustomerManager>();

    }
    void FixedUpdate()
    {
        Debug.DrawRay(this.transform.position, globalDestination ,Color.yellow);
        Debug.DrawRay(this.transform.position,this.transform.forward * 2,Color.green);
        FaceCustomerTowardsStore();
        if(paused)
        {
            

            handleCustomerFace();
            // Debug.LogWarning(gameObject.name +  " of Group" + transform.parent.transform.parent.name + " is Paused " );
            return;
        }
        else
        {
            spriterenderer.sprite = sideFace;

            moveTowardspoint();
        }
    }
    void FaceCustomerTowardsStore()
    {
        Quaternion rotationTowardsPlayer = Quaternion.LookRotation(player.transform.position - transform.position);
        rotationTowardsPlayer = Quaternion.Euler(0, rotationTowardsPlayer.eulerAngles.y , 0);
        transform.rotation = rotationTowardsPlayer;
    }
    void handleCustomerFace()
    {
        spriterenderer.sprite = frontFace;
    }
    Vector3 globalDestination;
    void moveTowardspoint()
    {
        // Debug.LogError(gameObject.name + " of Group" + transform.parent.transform.parent.name + " is Moving ");

        Vector3 destination = Vector3.MoveTowards(transform.position, points[i].transform.position, Speed * Time.deltaTime);
        globalDestination = destination;
        transform.position = new Vector3(destination.x, this.transform.position.y, destination.z);

        float distance = DistanceToPoint();
        //the if statement only looks at X value since we only need to match one value to work.
        if( distance < 0.1f && i == points.Length - 1)
        {
            // waits until it reaches the last point then resets the customer
            // Debug.Log(gameObject.name + " is at their last point MoveUpdate Fun");
            resetCustomer();
        }

        if( distance < 0.1f && i < points.Length - 1)
        {
            // if the customer gets close enough to the point it will move to the next point\
            // Debug.Log( gameObject.name +  " is at their next point MoveUpdate Fun");
            i++;
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
         // Debug.Log(gameObject.name + " has end their journey");
         transform.position = new Vector3(points[0].transform.position.x, this.transform.position.y, points[0].transform.position.z);
        // Debug.Log(gameObject.name + " is being disabled");
        this.gameObject.SetActive(false);
    }
    }
