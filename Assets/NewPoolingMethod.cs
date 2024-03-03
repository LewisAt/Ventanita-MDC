using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewPoolingMethod : MonoBehaviour
{
    public Transform[] foodLadle;
    private List<Transform> foodLadleList;
    public List<string> foodLadleNames;
    private foodIdentifier foodType;
    private foodIdentifier.typesOfFood foodValue;

    private void Start()
    {
        foodLadle = GetComponentsInChildren<Transform>();
        foodType = null;

        foodLadleList = foodLadle.ToList();
        CorrectList();
    }

    private void CorrectList()
    {
        foodLadleList.RemoveAt(0);
        print(foodLadleList.Count);
        for ( int i = 0; i <= foodLadleList.Count; i++ )
        {
            bool good = false;
            Transform t = foodLadleList[i];
            for (int o = 1; o < foodLadleNames.Count; o++)
            {
                string s = foodLadleNames[o];
                //print("comparing " + t + " with " + s);
                if (t.name == s)
                {
                    good = true;
                }
            }
            if ( !good ) foodLadleList.Remove(t);
            t.gameObject.SetActive(false);
        }
        foodLadle = foodLadleList.ToArray();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "food")
        {
            CheckWhatFoodItIs(other);
        }
    }

    public void CheckWhatFoodItIs(Collision other)
    {
        /*This method checks the collision and spawns the object according to the foodidentifier enum accessed
        on the object*/
        foodType = other.gameObject.GetComponent<foodIdentifier>();
        foodValue = foodType.food;
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
       /* if (!isLaldleFull && laldleType == LaldleIdentifier.TypeOfLaldle.general)
        {
            //Debug.Log("its triggering");
            if (foodType == null)
            {
                Debug.Log("its coming back null");
                return;
            }
            GameObject clone = Instantiate(prefabedFoods[(int)currentFood], this.transform.position, this.transform.rotation, this.transform);
            clone.transform.localRotation = Quaternion.Euler(-90, 0, 0);
            isLaldleFull = true;
        }*/
    }
}
