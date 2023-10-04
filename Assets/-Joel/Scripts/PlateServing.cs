using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;

public class PlateServing : MonoBehaviour
{
    LaldleTrigger laldletrigger;
    foodIdentifier food;
    foodIdentifier.foodPosition foodPos;
    bool mainFull = false;
    bool sideFull = false;
    bool isRice = false;
    bool laldleFull;
    bool plateFull = false;
    int xSides;

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision is triggering");
        if (other.gameObject.tag == "spoon")
        {
            GameObject clone = other.transform.GetChild(0).gameObject;
            clone.transform.localScale = Vector3.one * .1f;
            Debug.Log("specifically colliding with the spoon");
            food = clone.GetComponent<foodIdentifier>();
            if (food == null)
            {
                Debug.Log("food is null");
                return;
            }
            laldleFull = LaldleTrigger.isLaldleFull;
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
        food = other.GetComponent<foodIdentifier>();
        if (food == null)
        {
            Debug.Log("checkplateposition is coming back null for food");
            return;
        }
        foodPos = food.pos;
        attach((int)foodPos, other);
        
    }

    public void attach(int parent, GameObject other)
    {
        foodIdentifier script;
        foodIdentifier.typesOfFood foodtype;

        script = other.GetComponent<foodIdentifier>();
        foodtype = script.food;

        laldleFull = LaldleTrigger.isLaldleFull;
        GameObject clone = Instantiate(other);
        Destroy(clone.gameObject.GetComponent<Rigidbody>());

        if (parent == 0 && mainFull == false)
        {
            clone.transform.rotation = transform.GetChild(parent).rotation;

            clone.transform.SetParent(transform.GetChild(parent));

            clone.transform.localPosition = Vector3.zero;
            mainFull = true;
            LaldleTrigger.isLaldleFull = false;
            Destroy(other);
        }
        else if (parent == 0 && mainFull == true)
        {
            Destroy(other);
            Destroy(clone);
            LaldleTrigger.isLaldleFull = false;
        }
        else if (parent == 1 && sideFull == false && (int)foodtype != 3)
        {
            clone.transform.rotation = transform.GetChild(parent).rotation;
            clone.transform.SetParent(transform.GetChild(parent));
            clone.transform.localPosition = Vector3.zero; 
            sideFull = true;
            xSides++;
            LaldleTrigger.isLaldleFull = false;
            Destroy(other);
        }
        else if ((int)foodtype == 3)
        {
            clone.transform.rotation = transform.GetChild(parent + 1).rotation;
            clone.transform.SetParent(transform.GetChild(parent + 1));
            clone.transform.localPosition= Vector3.zero;
            LaldleTrigger.isLaldleFull =false;
            isRice = true;
            Destroy(other);
        }
        else
        {
            Destroy(clone);
            Destroy(other);
            LaldleTrigger.isLaldleFull = false;
        }
        CheckPlate(mainFull, sideFull, isRice);
    }
    public void CheckPlate(bool one, bool two, bool three)
    {
        if (one == true && two == true && three == true)
        {
            plateFull = true;
            Debug.Log("Plate is full!");        
            transform.GetComponentInChildren<Rigidbody>().isKinematic = false;
        }
        else
        {
            Debug.Log("plate is not full yet");
        }
    }
}
