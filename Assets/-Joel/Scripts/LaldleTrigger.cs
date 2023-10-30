
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LaldleTrigger : MonoBehaviour
{
    public GameObject[] prefabedFoods;
    public bool isLaldleFull = false;
    Transform spoon;
    foodIdentifier foodType;
    foodIdentifier.typesOfFood currentFood;
    LaldleIdentifier.TypeOfLaldle laldleType;

    private void Start()
    {
        laldleType = GetComponent<LaldleIdentifier>().typeOfLaldle;
    }
    private void OnCollisionEnter(Collision other)
    { 
        if (other.gameObject.tag == "food")
        {
            //spoon = transform.GetChild(0).gameObject.transform;
            CheckWhatFoodItIs(other);
        }
    }
    private void Update()
    {
        print(isLaldleFull);
    }
    public void CheckWhatFoodItIs(Collision other)
    {
        foodType = other.gameObject.GetComponent<foodIdentifier>();
        currentFood = foodType.food;
        if (!isLaldleFull && laldleType.ToString() == currentFood.ToString())
        {
            //Debug.Log("its triggering");
            if (foodType == null)
            {
                Debug.Log("its coming back null");
                return;
            }
            GameObject clone = Instantiate(prefabedFoods[(int)currentFood], this.transform.position, this.transform.rotation, this.transform);
            clone.transform.localScale = Vector3.one;
            isLaldleFull = true;
        }
        else if (!isLaldleFull && laldleType == LaldleIdentifier.TypeOfLaldle.general)
        {
            //Debug.Log("its triggering");
            if (foodType == null)
            {
                Debug.Log("its coming back null");
                return;
            }
            GameObject clone = Instantiate(prefabedFoods[(int)currentFood], this.transform.position, this.transform.rotation, this.transform);
            clone.transform.localScale = Vector3.one;
            isLaldleFull = true;
        }
    }
}
