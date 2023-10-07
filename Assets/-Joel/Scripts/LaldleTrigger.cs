using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LaldleTrigger : MonoBehaviour
{
    public GameObject[] prefabedFoods;
    public static bool isLaldleFull = false;
    Transform spoon;
    //Create a variable for the Script and the enum
    foodIdentifier foodType;
    foodIdentifier.typesOfFood currentFood;
    
    private void OnCollisionEnter(Collision other)
    { 
        if (other.gameObject.tag == "food")
        {
            spoon = transform.GetChild(0).gameObject.transform;
            CheckWhatFoodItIs(other);
        }
    }
    public void CheckWhatFoodItIs(Collision other)
    {
        foodType = other.gameObject.GetComponent<foodIdentifier>();
        currentFood = foodType.food;
        if (!isLaldleFull)
        {
            Debug.Log("its triggering");
            if (foodType == null)
            {
                Debug.Log("its coming back null");
                return;
            }
            GameObject clone = Instantiate(prefabedFoods[(int)currentFood], spoon.transform.position, spoon.transform.rotation, spoon);
            clone.transform.localScale = Vector3.one;
            isLaldleFull = true;
            Debug.Log(clone.name + " was picked up");
        }
    }
    /*public void CheckWhatSectionOnPlate(Collision other)
    {
        Debug.Log("I am triggering from the plate collision");
        GameObject clone = Instantiate(prefabedFoods[(int)currentFood], this.GetComponentInChildren<Transform>());
    }*/ 
    
}
