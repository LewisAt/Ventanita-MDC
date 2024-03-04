using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewPoolingMethod : MonoBehaviour
{
    public foodIdentifier[] foodLadle;
    public List<foodIdentifier> foodLadleList;
    private List<foodIdentifier> foodIdentifierList;
    public bool isLadleFull;


    private foodIdentifier foodType;
    private foodIdentifier.typesOfFood foodValue;

    private void Start()
    {
        foodLadle = GetComponentsInChildren<foodIdentifier>();

        foodLadleList = foodLadle.ToList();
        CorrectList();
    }

    private void CorrectList()
    {
        for ( int i = 0; i < foodLadleList.Count; i++ )
        {
            foodIdentifier t = foodLadleList[i];
            t.GetComponent<MeshRenderer>().enabled = false;
            if (t.GetComponentInChildren<MeshRenderer>() != null)
            {
                MeshRenderer[] temp;
                temp = t.GetComponentsInChildren<MeshRenderer>();
                foreach ( MeshRenderer r in temp ) { r.enabled = false; }
            }
        }
        foodLadle = foodLadleList.ToArray();
    }

    private void OnCollisionEnter(Collision contact)
    {
        if (contact.gameObject.tag == "food" && contact.gameObject.GetComponent<foodIdentifier>() != null)
        {
            foodIdentifier.typesOfFood foodType = contact.gameObject.GetComponent<foodIdentifier>().food;
            CheckWhatFoodItIs(foodType);
        }
    }

    public void CheckWhatFoodItIs(foodIdentifier.typesOfFood foodType)
    {
        /*This method checks the collision and spawns the object according to the foodidentifier enum accessed
        on the object*/
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
    }
}
