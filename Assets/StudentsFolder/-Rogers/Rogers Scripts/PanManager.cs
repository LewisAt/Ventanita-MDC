using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PanManager : MonoBehaviour
{
    public GameObject[] cookableResults;
    public GameObject[] cookableRawFood;
    spacePos[] cookingPos;
    GameObject cookingResult;
    public GameObject foodText;
    rawPlaceHolder[] cookableRawScripts;
    rawPlaceHolder collidedFoodScript;
    Burning burnCanceled;

    int upgradedCookTime;
    public int defaultCookTime;
    int confirmedCookTime;
    [HideInInspector]
    static public int foodCooking = 0;
    public int MAXFood;
    bool isCookable;
    void Start()
    {
        addScripts();
        if (upgradedCookTime == 0) confirmedCookTime = defaultCookTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        bool HasRaw;
        bool HasSpace = isSpace();
        GameObject foodCol = collision.gameObject;

        if (foodCol.GetComponent<rawPlaceHolder>() != null)
        {
            collidedFoodScript = foodCol.GetComponent<rawPlaceHolder>();
            HasRaw = true;
        }
        else HasRaw = false;
        if (foodCol.tag == "food" && HasRaw && foodCooking < MAXFood && HasSpace)
        {
            foodCol.transform.parent = null;
            canCook();
            if (isCookable) addBurning(foodCol);

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
        cookableRawScripts = new rawPlaceHolder[cookableRawFood.Length];
        cookingPos = new spacePos[this.gameObject.transform.childCount];
        for (int i = 0; i < cookableRawFood.Length; i++)
        {
            cookableRawScripts[i] = cookableRawFood[i].GetComponent<rawPlaceHolder>();
        }
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            cookingPos[i] = this.gameObject.transform.GetChild(i).GetComponent<spacePos>();
        }
    }

    void addBurning(GameObject food)
    {
        foodCooking++;
        Burning burning = food.AddComponent<Burning>();
        findSpace(burning);
        burning.startCooking(foodText, cookingResult, confirmedCookTime);
    }
    bool isSpace()
    {
        for (int i = 0; i < cookingPos.Length; i++)
        {
            if (!cookingPos[i].hasFood)
            {
                return true;
            }
        }
        return false;
    }
    void findSpace(Burning foodsBurning)
    {
        for(int i = 0; i < cookingPos.Length; i++)
        {
            if (!cookingPos[i].hasFood)
            {
                foodsBurning.TakeSpace(cookingPos[i].gameObject);
                return;
            }
        }
    }
    void canCook()
    {
        for (int i = 0; i < cookableRawFood.Length; i++)
        {
            if (collidedFoodScript.rawFood == cookableRawScripts[i].rawFood)
            {
                cookingResult = cookableResults[i];
                isCookable = true;
                return;
            }
        }
    }
}
