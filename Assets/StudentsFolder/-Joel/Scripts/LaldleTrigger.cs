
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LaldleTrigger : MonoBehaviour
{
    public GameObject[] prefabedFoods;
    public bool isLaldleFull;
    Transform spoon;
    foodIdentifier foodType;
    foodIdentifier.typesOfFood currentFood;
    LaldleIdentifier.TypeOfLaldle laldleType;

    private void Start()
    {
        // Causes a null reference exception.
        laldleType = GetComponent<LaldleIdentifier>().typeOfLaldle;
    }
    private void OnCollisionEnter(Collision other)
    { 
        if (other.gameObject.tag == "food")
        {
            /*The below comment was commented out due to this line of code no longer being used. Was originally
            used in the early stages as the spoon was made of multiple objects.*/
            //spoon = transform.GetChild(0).gameObject.transform;
            CheckWhatFoodItIs(other);
        }
    }
    private void Update()
    {
        //print(isLaldleFull);
    }
    public void CheckWhatFoodItIs(Collision other)
    {
        /*This method checks the collision and spawns the object according to the foodidentifier enum accessed
        on the object*/
        foodType = other.gameObject.GetComponent<foodIdentifier>();
        currentFood = foodType.food;
        /*if (!isLaldleFull && laldleType.ToString() == currentFood.ToString())
        {
            //Debug.Log("its triggering");
            if (foodType == null)
            {
                Debug.Log("its coming back null");
                return;
            }
            GameObject clone = Instantiate(prefabedFoods[(int)currentFood], this.transform.position, this.transform.rotation, this.transform);
            clone.transform.localScale = new Vector3 (1,1,1);
            isLaldleFull = true;
        }*/
        if (!isLaldleFull && laldleType == LaldleIdentifier.TypeOfLaldle.general)
        {
            //Debug.Log("its triggering");
            if (foodType == null)
            {
                Debug.Log("its coming back null");
                return;
            }
            GameObject clone = Instantiate(prefabedFoods[(int)currentFood], this.transform.position, this.transform.rotation, this.transform);    
            clone.transform.localRotation = Quaternion.Euler (-90,0,0);
            isLaldleFull = true;
        }
    }
}
