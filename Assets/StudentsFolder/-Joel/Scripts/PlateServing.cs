using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.XR;
using UnityEngine;

public class PlateServing : MonoBehaviour
{
    LaldleTrigger laldletrigger;
    foodIdentifier Food;
    foodIdentifier.foodPosition foodPos;
    foodIdentifier.typesOfFood foodtype;

    bool mainFull = false;
    bool sideFull = false;
    bool isRice = false;
    LaldleTrigger laldleFull;
    bool plateFull = false;
    int xSides = 0;
    public float xoffset = 0;
    public float zoffset = 0;
    int currentSide;

   /*This is the main functionality of how the plate receives the food and knows where to put it
    * It seperates it into main, rice, and side; side allowing up to 4 objects being added. 
    * Once the plate is full, a bool (platefull) will return true and will not allow anymore objects
    * to be added.*/

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("collision is triggering");
        if (other.gameObject.tag == "spoon" && other.transform.childCount > 0)
        {
            GameObject clone = other.transform.GetChild(0).gameObject;
            clone.transform.localScale = Vector3.one * .1f;
            //Debug.Log("specifically colliding with the spoon");
            Food = clone.GetComponent<foodIdentifier>();
            if (Food == null)
            {
                Debug.Log("food is null");
                return;
            }
            laldleFull = other.gameObject.GetComponent<LaldleTrigger>();
            if (laldleFull)
            {
                checkPlatePosition(clone);
            }
        }
    }

    public void Start()
    {
        plateFull = false;
    }
    public void checkPlatePosition(GameObject other)
    {
        Food = other.GetComponent<foodIdentifier>();
        if (Food == null)
        {
            Debug.Log("checkplateposition is coming back null for food");
            return;
        }
        foodPos = Food.pos;
        attach((int)foodPos, other);
        
    }

    public void attach(int parent, GameObject other)
    {
        Food = other.GetComponent<foodIdentifier>();
        foodtype = Food.food;

        GameObject clone = Instantiate(other);
        Destroy(clone.gameObject.GetComponent<Rigidbody>());

        if (parent == 0 && mainFull == false)
        {
            clone.transform.rotation = transform.GetChild(parent).rotation;
            clone.transform.SetParent(transform.GetChild(parent));
            clone.transform.localPosition = new Vector3 (0,0.05f,0);
            clone.transform.localScale = new Vector3(0.15f, 0.1f, 0.15f);
            mainFull = true;
            laldleFull.isLaldleFull = false;
            Destroy(other);
        }
        else if (parent == 0 && mainFull == true)
        {
            Destroy(other);
            Destroy(clone);
            laldleFull.isLaldleFull = false;
        }
        else if (parent == 1 && sideFull == false && (int)foodtype != 3)
        {
            if (xSides <= 3)
            {
                if (xSides == 0)
                {
                    xoffset = -0.05f;
                    zoffset = -0.05f;    
                }
                else if (xSides == 1)
                {
                    xoffset = 0.05f;
                    zoffset = -0.05f;
                }
                else if (xSides == 2)
                {
                    xoffset = -0.05f;
                    zoffset = 0.05f;
                }
                else if (xSides == 3)
                {
                    xoffset = 0.05f;
                    zoffset = 0.05f;
                    sideFull = true;
                }
                clone.transform.rotation = transform.GetChild(parent).rotation;
                clone.transform.SetParent(transform.GetChild(parent));
                clone.transform.localPosition = new Vector3(xoffset, 0.01f, zoffset);
                clone.transform.localScale = new Vector3(500,500, 500);
                xSides++;
            }
            laldleFull.isLaldleFull = false;
            Destroy(other);
        }
        else if ((int)foodtype == 3 && isRice == false)
        {
            clone.transform.rotation = transform.GetChild(parent + 1).rotation;
            clone.transform.SetParent(transform.GetChild(parent + 1));
            clone.transform.localPosition = new Vector3 (0,0.05f,0);
            clone.transform.localScale = new Vector3 (0.15f, 0.1f, 0.15f);
            laldleFull.isLaldleFull = false;
            isRice = true;
            Destroy(other);
        }
        else
        {
            Destroy(clone);
            Destroy(other);
            laldleFull.isLaldleFull = false;
        }
        CheckPlate(mainFull, sideFull, isRice);
    }
    public void CheckPlate(bool one, bool two, bool three)
    {
        if (one == true && two == true && three == true)
        {
            plateFull = true;
            //Debug.Log("Plate is full!");        
            transform.GetComponentInChildren<Rigidbody>().isKinematic = false;
        }
        else
        {
            //Debug.Log("plate is not full yet");
        }
    }

    public void Swipe()
    {
        xSides = 0;
        mainFull = false;
        sideFull = false;
        isRice = false;
    }
}
