using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/*
====================================================================================================
                                        SPOON SCRIPT
====================================================================================================
This script is attached to the spoon object in the game.
It handles pooling and identification of food items in the spoon.
! it's the core of the game make sure this works properly.
^ this script uses collision enter not tirgger enter
====================================================================================================
*/
public class NewPoolingMethod : MonoBehaviour
{


    private foodIdentifier foodType;

    [HideInInspector] public foodIdentifier CurrentlyActiveFood;
    private foodIdentifier[] foodInLadle;
    private foodIdentifier.typesOfFood foodValue;

    private void Start() 
    {
        PopulateLadleFoods();
    }
    void PopulateLadleFoods()
    {
        //! double check that this works IDK if it looks at all children
        //* it does work
        foodInLadle = GetComponentsInChildren<foodIdentifier>();
        if(foodInLadle.Length == 0)
        {
            Debug.LogError("No food items in ladle");
        }
        else if(foodInLadle == null)
        {
            Debug.LogError("Null food items in ladle");
        }
        else
        {
            Debug.Log("Food items in ladle: " + foodInLadle.Length);
        }
        for (int i = 0; i < foodInLadle.Length; i++)
        {
            foodInLadle[i].gameObject.SetActive(false);
        }
    }

    void setActiveFood(foodIdentifier food)
    {
        for (int i = 0; i < foodInLadle.Length; i++)
        {
            if(foodInLadle[i].food == food.food)
            {
                CurrentlyActiveFood = foodInLadle[i];
                CurrentlyActiveFood.gameObject.SetActive(true);
            }
        }
    }
    private void  OnTriggerEnter(Collider other)
     {
        Debug.Log("collision is triggering");
        if(other.gameObject.tag == "food" && other.gameObject.GetComponent<foodIdentifier>() != null
        && CurrentlyActiveFood == null)
        {
            foodType = other.gameObject.GetComponent<foodIdentifier>();
            setActiveFood(foodType);
        }
    }
    public void ClearCurrentFood()
    {
        if(CurrentlyActiveFood != null)
        {
        CurrentlyActiveFood.gameObject.SetActive(false);
        CurrentlyActiveFood = null;
        }
        
    }

    /* private void Start()
    {
        foodLadle = GetComponentsInChildren<foodIdentifier>();

        foodLadleList = foodLadle.ToList();
        CorrectList();
    }

    private void CorrectList()
    {
    }

    private void OnCollisionEnter(Collision contact)
    {
        if (contact.gameObject.tag == "food" && contact.gameObject.GetComponent<foodIdentifier>() != null)
        {

            CheckWhatFoodItIs(contact.gameObject.GetComponent<foodIdentifier>().food);
        }
    }

    public void CheckWhatFoodItIs(foodIdentifier.typesOfFood foodType)
    {
        This method checks the collision and spawns the object according to the foodidentifier enum accessed
        on the object
        if (!isLadleFull)
        {
            foreach (foodIdentifier f in foodLadle)
            {
                if (foodType == f.food)
                {
                    f.GetComponent<MeshRenderer>().enabled = true;
                    if (f.GetComponentInChildren<MeshRenderer>() != null)
                    {
                        MeshRenderer[] temp;
                        temp = f.GetComponentsInChildren<MeshRenderer>();
                        foreach (MeshRenderer r in temp) { r.enabled = true; }
                    }
                }
            }
            isLadleFull = true;
        }
    } */
}
