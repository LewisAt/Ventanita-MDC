using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateIdentifier : MonoBehaviour
{
    //declare a foodIdentifier for both main and side 
    [HideInInspector]
    public MainFoods plateMain = MainFoods.None;
    [HideInInspector]
    public SideFoods plateSide = SideFoods.None;
    [HideInInspector]
    public int SideCount = 0;
    [HideInInspector]
    public SideFoods plateSide1= SideFoods.None;
    [HideInInspector]
    public int SideCount1 = 0;
    [HideInInspector]
    public bool hasCoffee = false;
  
    [HideInInspector]
    public bool hasRice = false;
    private PlateServing plateServe;
    void Start()
    {
        plateServe = GetComponent<PlateServing>();
    }
    //! this needs to be called instead of destroy and instantiate
    public void ResetPlate()
    {
        plateMain = MainFoods.None;
        plateSide = SideFoods.None;
        SideCount = 0;
        plateSide1 = SideFoods.None;
        SideCount1 = 0;
        hasCoffee = false;
        hasRice = false;
        plateServe.ResetAll();
        

    }
    private void OnTriggerEnter(Collider spoon)
    {
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

            GameObject food = spoonScript.CurrentlyActiveFood.gameObject;
            print("Updating Food");

            updateContents(food);
            spoonScript.ClearCurrentFood();
            
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
