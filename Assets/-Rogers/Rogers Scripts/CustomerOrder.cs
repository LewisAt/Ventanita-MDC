using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

//this Script Contains Possible Orders the Customer can make
public class CustomerOrder : MonoBehaviour
{
    public SideFoods sides;
    public SideFoods sides1;
    int NumOfSides;
    int NumOfSides1;


    public MainFoods Mains;
    public bool hasRice = false;
<<<<<<< HEAD
    bool WantsCoffee;
=======
    //bool WantsCoffee;
>>>>>>> Frida-Demo-Doppel
    [HideInInspector]

    public float foodsCost;
    string MealName;
    //Get this one for the ui
    [HideInInspector]
    public string ConfirmedMealName;

    public string MealDescription;


    //string riceDescription = "Something about Rice";
    //string CoffeeDescription = "Something about Cafe Con Leche";


    public void randomizeFactors()
    {

        if (sides != SideFoods.None)
        {
            NumOfSides = Random.Range(1, 3);
<<<<<<< HEAD
=======

>>>>>>> Frida-Demo-Doppel
        }
        else
            NumOfSides = 0;

        if (sides1 != SideFoods.None)
        {
            NumOfSides1 = Random.Range(1, 3);
        }
        else
            NumOfSides1 = 0;

        WantsCoffee = Random.value < 0.5f;
    }

    public void StartFood()
    {
        float TotalCost = 0;

<<<<<<< HEAD
=======
        /*
>>>>>>> Frida-Demo-Doppel
        if (WantsCoffee)
        {
            TotalCost += 5f;
            MealName += "Cafe ";
        }
        if(WantsCoffee && hasRice)
        {
            MealName += "y ";
        }
<<<<<<< HEAD
=======
        */
>>>>>>> Frida-Demo-Doppel
        if (hasRice)
        {
            TotalCost += 7.5f;
            MealName += "Arroz ";
        }
        
        if(hasRice && Mains != MainFoods.None)
        {
            MealName += "Con ";
        }
        switch (Mains)
        {

            case MainFoods.None:
                break;
            case MainFoods.Rabo:
                TotalCost += 20;
                MealName += "Rabo Encendido";
                break;

            case MainFoods.Fricase:
                TotalCost += 15;
                MealName += "Fricase de Pollo";

                break;
            case MainFoods.Beans:
                TotalCost += 10;
                MealName += "Frijoles";

                break;
        }
        if(sides != SideFoods.None)
        {
<<<<<<< HEAD
            if(WantsCoffee == true || hasRice == true || Mains != MainFoods.None)
            {
                MealName += " Y ";
            }
=======
            
            if(/*WantsCoffee == true ||*/ hasRice == true || Mains != MainFoods.None)
            {
                MealName += " Y ";
            }
            
>>>>>>> Frida-Demo-Doppel

        }
        switch (sides)
        {
            case SideFoods.None:
                break;


            case SideFoods.croqueta:
                TotalCost += 2.5f * NumOfSides;
                MealName += NumOfSides + " Croquetas ";
                break;

            case SideFoods.tostone:
                TotalCost += 3.5f * NumOfSides;
                MealName += NumOfSides + " Tostones ";
<<<<<<< HEAD
=======

>>>>>>> Frida-Demo-Doppel
                break;

            case SideFoods.maduro:
                TotalCost += 4f * NumOfSides;
                MealName += NumOfSides + " Platano Maduro";
                break;
        }
        if (sides1 != SideFoods.None) 
        {
            MealName += " Y ";
        }
        switch (sides1)
        {
            case SideFoods.None:
                break;


            case SideFoods.croqueta:
                TotalCost += 2.5f * NumOfSides;
                MealName += NumOfSides + " Croquetas ";
                break;

            case SideFoods.tostone:
                TotalCost += 3.5f * NumOfSides;
                MealName += NumOfSides + " Tostones ";
<<<<<<< HEAD
=======

>>>>>>> Frida-Demo-Doppel
                break;

            case SideFoods.maduro:
                TotalCost += 4f * NumOfSides;
                MealName += NumOfSides + " Platano Maduro";
<<<<<<< HEAD
=======

>>>>>>> Frida-Demo-Doppel
                break;
        }

        foodsCost = TotalCost;
        ConfirmedMealName = MealName;
        MealName = "";
    }
    public void addNumOfSides()
    {
        NumOfSides++;
    }
<<<<<<< HEAD
=======
    /*
>>>>>>> Frida-Demo-Doppel
    public void addCoffee()
    {
        WantsCoffee = true;
    }
<<<<<<< HEAD
=======
    */
>>>>>>> Frida-Demo-Doppel
    public int getNumOfSides()
    { return NumOfSides; }
    public int getNumOfSides1()
    { return NumOfSides1; }
    public float getFoodCost()
    { return foodsCost; }
    public string getMealName()
    { return ConfirmedMealName; }
<<<<<<< HEAD
    public bool getCoffeeBool()
    { return WantsCoffee; }
=======
    /*
    public bool getCoffeeBool()
    { return WantsCoffee; }
    */
>>>>>>> Frida-Demo-Doppel
}

public enum SideFoods
{
    None,
    croqueta,
    tostone,
    maduro
}
public enum MainFoods
{
    None,
    Rabo,
    Fricase,
<<<<<<< HEAD
    Frijoles
}
=======
    Beans
}

>>>>>>> Frida-Demo-Doppel
