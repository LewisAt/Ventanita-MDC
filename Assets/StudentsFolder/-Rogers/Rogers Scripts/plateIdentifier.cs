using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateIdentifier : MonoBehaviour
{
    //declare a foodIdentifier for both main and side 
    [HideInInspector]
    public MainFoods plateMain;
    [HideInInspector]
    public SideFoods plateSide;
    [HideInInspector]
    public int SideCount = 0;
    [HideInInspector]
    public SideFoods plateSide1;
    [HideInInspector]
    public int SideCount1 = 0;
    [HideInInspector]
    public bool hasCoffee = false;
    [HideInInspector]
    public bool hasRice = false;
    void OnCollisionEnter(Collision spoon)
    {
        if (spoon.gameObject.tag == "spoon" && spoon.transform.childCount > 0)
        {
            GameObject food = spoon.transform.GetChild(0).gameObject;
            print("Updating Food");
            updateContents(food);
            //print("For Jojo: it is coming back NULL");
        }
        //placeholder for coffee
        if (spoon.gameObject.name == "Cafe")
        {
            hasCoffee = true;
        }
    }

    void updateContents(GameObject food)
    {
        int numOfEnum = 0;
        
        string foodString = food.GetComponent<foodIdentifier>().food.ToString();
        int maxEnumMain = System.Enum.GetValues(typeof(MainFoods)).Length;
        int maxEnumSide = System.Enum.GetValues(typeof(SideFoods)).Length;
        foodIdentifier curr = food.GetComponent<foodIdentifier>();
        if((int)curr.food == 3)
        {
            Debug.Log("ricewasAdded");
            hasRice = true;
        }
        
        
        //loops until both main and side enums ends
        //Compares string of enums if they match they equal that value
        while (numOfEnum < maxEnumMain && numOfEnum < maxEnumSide)
        {
            if (foodString == ((MainFoods)numOfEnum).ToString() && plateMain == MainFoods.None) 
            {
                plateMain = (MainFoods)numOfEnum;
            Debug.Log((MainFoods)numOfEnum);

            }
            if (foodString == ((SideFoods)numOfEnum).ToString())
            {
                //Makes sure plateSide isnt changed by any other food collision
                if (plateSide != SideFoods.None && plateSide1 == SideFoods.None && plateSide != (SideFoods)numOfEnum) plateSide1 = (SideFoods)numOfEnum;

                if (plateSide1 == (SideFoods)numOfEnum && SideCount1 < 2 && plateSide != SideFoods.None) SideCount1++;

                if (plateSide == SideFoods.None) plateSide = (SideFoods)numOfEnum;

                if(plateSide == (SideFoods)numOfEnum && SideCount < 2) SideCount++;



            }
            
            numOfEnum++;
        }
        
        if(foodString == "Arroz")
        {
            hasRice = true;
        }
        print(plateMain);
        print(plateSide);
        print(plateSide1);
        print(SideCount);
        print(SideCount1);
        
    }
}
