using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cookFood : MonoBehaviour
{
    //========Synopsis========
    //Cook food need two gameObjects arrays Cookable Results which is the raw and cooked version of
    //the food it collides with and Instantiate it after time has reach the Confirmed cook time
    public GameObject[] cookableResults;
    public GameObject[] cookableRawFood;
    foodIdentifier[] cookableRawScripts;
    foodIdentifier collidedFoodScript;
    GameObject collidedObject;
    public Text CookProgTime;

    int resultArrayNum;
    int upgradedCookTime;
    public int defaultCookTime;
    int confirmedCookTime;
    int timePassed;
    float cookProgPercent;

    bool isCooking;
    bool isCookable;
    // Start is called before the first frame update
    void Start()
    {
        resetValues();
        addScripts();
    }

    // Update is called once per frame
    void Update()
    {
        //This calculate the cooked percentage
        if(isCooking)
        {
            cookProgPercent = 100 - ((confirmedCookTime - timePassed) * 100 / confirmedCookTime);

        }
        else
        {
            cookProgPercent = 0;
        }
        CookProgTime.text = "" + cookProgPercent + "%";
        if (timePassed == confirmedCookTime && isCookable)
        {
            GetCooked();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collidedObject == null && collision.gameObject.tag == "food")
        {
            collidedObject = collision.gameObject;
            collidedFoodScript = collidedObject.GetComponent<foodIdentifier>();
            canCook();
            if (isCookable)
            {
                StartCoroutine(cookTime());

            }


        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject == collidedObject)
        {
            resetValues();
            StopCoroutine(cookTime());
        }
    }
    void addScripts()
    {
        cookableRawScripts = new foodIdentifier[cookableRawFood.Length];
        for(int i = 0; i < cookableRawFood.Length; i++)
        {
            cookableRawScripts[i] = cookableRawFood[i].GetComponent<foodIdentifier>();
        }
    }
    void resetValues()
    {
        if (upgradedCookTime == 0) confirmedCookTime = defaultCookTime;
        collidedObject = null;
        isCookable = false;
        isCooking = false;
        timePassed = 0;

    }
    void canCook()
    {
        for(int i = 0; i < cookableRawFood.Length; i++)
        {
            if (cookableRawScripts[i].food == collidedFoodScript.food)
            {
                resultArrayNum = i;
                isCookable = true;
                isCooking = true;
                return;
            }
        }
    }
    void GetCooked()
    {
        Instantiate(cookableResults[resultArrayNum], collidedObject.transform.position, Quaternion.identity);
        Destroy(collidedObject);
        resetValues();
    }
    IEnumerator cookTime()
    {
        while(timePassed != confirmedCookTime && isCooking)
        {
            yield return new WaitForSeconds(1);
            timePassed++;
        }
    }
}
