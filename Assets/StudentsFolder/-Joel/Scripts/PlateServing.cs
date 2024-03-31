using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.XR;
using UnityEngine;


//!there is currently do defence for when a position is full.
//!this means you can just add everything onto the plate and it will just stack on top of each other
public class PlateServing : MonoBehaviour
{
    public GameObject Arroz;
    public GameObject Frijoles;
    public GameObject Fricase;
    public GameObject Rabo;


    public GameObject[] croquetaGroup;

    public GameObject[] maduroGroup;

    public GameObject[] TostoneGroup;



    public void Start()
    {
        ResetAll();
    }

    public void setFrijoles()
    {
        Frijoles.SetActive(true);
    }
    public void setCroquetaGroup(int num)
    {
        for (int i = 0; i < num; i++)
        {
            croquetaGroup[i].SetActive(true);
        }
    }
    public void setFricase()
    {
        Fricase.SetActive(true);
    }
    public void setMaduroGroup(int num)
    {
        for (int i = 0; i < num; i++)
        {
            maduroGroup[i].SetActive(true);
        }
    }
    public void setRabo()
    {
        Rabo.SetActive(true);
    }
    public void setTostoneGroup(int num)
    {
        for (int i = 0; i < num; i++)
        {
            TostoneGroup[i].SetActive(true);
        }
    }
    public void setArroz()
    {
        Arroz.SetActive(true);
    }
    public void setCroqueta(int num)
    {
        for (int i = 0; i < num; i++)
        {
            croquetaGroup[i].SetActive(true);
        }
    }
    public void setMaduro(int num)
    {
        for (int i = 0; i < num; i++)
        {
            maduroGroup[i].SetActive(true);
        }
    }
    public void setTostone(int num)
    {
        for (int i = 0; i < num; i++)
        {
            TostoneGroup[i].SetActive(true);
        }
    }

    public void ResetAll()
    {
        Frijoles.SetActive(false);
        Fricase.SetActive(false);
        Rabo.SetActive(false);
        Arroz.SetActive(false);
        for (int i = 0; i < croquetaGroup.Length; i++)
        {
            croquetaGroup[i].SetActive(false);
        }
        for (int i = 0; i < maduroGroup.Length; i++)
        {
            maduroGroup[i].SetActive(false);
        }
        for (int i = 0; i < TostoneGroup.Length; i++)
        {
            TostoneGroup[i].SetActive(false);
        }
    }









   /*  LaldleTrigger laldletrigger;
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
    * to be added.

    private void OnCollisionEnter(Collision spoon)
    {
        //Debug.Log("collision is triggering");
        if (spoon.gameObject.tag == "spoon")
        {
             //& if there is lag this might be the reason
            NewPoolingMethod spoonScript = spoon.gameObject.GetComponent<NewPoolingMethod>();
            if(spoonScript == null)
            {
                Debug.Log("Spoon script is null");
                return;
            }
            else if(spoonScript != null)
            {
                Debug.Log("Spoon script is not null");
            }
            if(spoonScript.CurrentlyActiveFood == null)
            {
                Debug.Log("Currently active food is null");
                return;
            }
            else if(spoonScript.CurrentlyActiveFood != null)
            {
                Debug.Log("Currently active food is not null");
            }
            else
            {
            }
            GameObject clone = spoon.transform.GetChild(0).gameObject;
            clone.transform.localScale = Vector3.one * .1f;
            //Debug.Log("specifically colliding with the spoon");
            Food = clone.GetComponent<foodIdentifier>();
            if (Food == null)
            {
                Debug.Log("food is null");
                return;
            }
            laldleFull = spoon.gameObject.GetComponent<LaldleTrigger>();
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
                clone.transform.localPosition = new Vector3(xoffset, 0.05f, zoffset);
                clone.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
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
    } */
}
