using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanManager : MonoBehaviour
{
    public GameObject[] cookableResults;
    public GameObject[] cookableRawFood;
    GameObject cookingResult;
    public GameObject foodText;
    foodIdentifier[] cookableRawScripts;
    foodIdentifier collidedFoodScript;
    Burning burnCanceled;

    int upgradedCookTime;
    public int defaultCookTime;
    int confirmedCookTime;
    int foodCooking = 0;
    public int MAXFood;
    bool isCookable;
    // Start is called before the first frame update
    void Start()
    {
        addScripts();
        if (upgradedCookTime == 0) confirmedCookTime = defaultCookTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        bool HasRaw;
        if (collision.gameObject.GetComponent<rawPlaceHolder>() != null)
        {
            collidedFoodScript = collision.gameObject.GetComponent<foodIdentifier>();
            HasRaw = true;
        }
        else HasRaw = false;
        if (collision.gameObject.tag == "food" && HasRaw)
        {
            canCook();
            if(isCookable && foodCooking < MAXFood) addBurning(collision.gameObject);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        bool HasBurning;
        if (collision.gameObject.GetComponent<Burning>() != null)
        {
            burnCanceled = collision.gameObject.GetComponent<Burning>();
            HasBurning = true;
        }
        else HasBurning = false;
        if(HasBurning)
        {
            burnCanceled.StopCoroutine(burnCanceled.getLastCoroutine());
            foodCooking--;
            burnCanceled.foodReset();
            Destroy(burnCanceled);
        }
    }

    void addScripts()
    {
        cookableRawScripts = new foodIdentifier[cookableRawFood.Length];
        for (int i = 0; i < cookableRawFood.Length; i++)
        {
            cookableRawScripts[i] = cookableRawFood[i].GetComponent<foodIdentifier>();
        }
    }

    void addBurning(GameObject food)
    {
        foodCooking++;
        Burning burning = food.AddComponent<Burning>();
        burning.startCooking(foodText, cookingResult, confirmedCookTime);
    }
    void canCook()
    {
        for (int i = 0; i < cookableRawFood.Length; i++)
        {
            if (collidedFoodScript.food == cookableRawScripts[i].food)
            {
                cookingResult = cookableResults[i];
                isCookable = true;
                return;
            }
        }
    }
}
