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
    bool WantsCoffee = false;
    float foodsCost;
    string MealName;
    //Get this one for the ui
    string ConfirmedMealName;

    public string MealDescription;


    //string riceDescription = "Something about Rice";
    //string CoffeeDescription = "Something about Cafe Con Leche";
    string MainDescription = "";
    string SideDescription = "";

    public void randomizeFactors()
    {

        if (sides != SideFoods.None)
        {
            NumOfSides = Random.Range(1, 3);
            print("Amount for the first Side: " + NumOfSides);
        }
        else
            NumOfSides = 0;

        if (sides1 != SideFoods.None)
        {
            NumOfSides1 = Random.Range(1, 3);
            print("Amount for the second Sides: " + NumOfSides1);
        }
        else
            NumOfSides1 = 0;

        WantsCoffee = Random.value < 0.5f;
    }

    public void StartFood()
    {
        float TotalCost = 0;

        if (WantsCoffee)
        {
            TotalCost += 5f;
            MealName += "Cafe ";
        }
        if(WantsCoffee && hasRice)
        {
            MealName += "y ";
        }
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
                MainDescription = "None";
                break;
            case MainFoods.Rabo:
                TotalCost += 20;
                MealName += "Rabo Encendido";
                MainDescription = "something about Rabo";
                break;

            case MainFoods.Fricase:
                TotalCost += 15;
                MealName += "Fricase de Pollo";
                MainDescription = "something about Fricase";

                break;
            case MainFoods.Frijoles:
                TotalCost += 10;
                MealName += "Frijoles";
                MainDescription = "something about Frijoles";

                break;
        }
        if(sides != SideFoods.None)
        {
            if(WantsCoffee == true || hasRice == true || Mains != MainFoods.None)
            {
                MealName += " Y ";
            }

        }
        switch (sides)
        {
            case SideFoods.None:
                MealName += " solo";
                SideDescription = "None";
                break;


            case SideFoods.croqueta:
                TotalCost += 2.5f * NumOfSides;
                MealName += NumOfSides + " Croquetas ";

                SideDescription = "something about Croquetas";
                break;

            case SideFoods.tostone:
                TotalCost += 3.5f * NumOfSides;
                MealName += NumOfSides + " Tostones ";
                SideDescription = "something about Tostones";

                break;
            case SideFoods.maduro:
                TotalCost += 4f * NumOfSides;
                MealName += NumOfSides + " Platano Maduro";
                SideDescription = "something about Maduros";

                break;
        }
        if (sides1 != SideFoods.None) 
        {
            MealName += " Y ";
        }
        switch (sides1)
        {
            case SideFoods.None:
                if(sides != SideFoods.None) MealName += " solo";
                SideDescription = "None";
                break;


            case SideFoods.croqueta:
                TotalCost += 2.5f * NumOfSides;
                MealName += NumOfSides + " Croquetas ";

                SideDescription = "something about Croquetas";
                break;

            case SideFoods.tostone:
                TotalCost += 3.5f * NumOfSides;
                MealName += NumOfSides + " Tostones ";
                SideDescription = "something about Tostones";

                break;
            case SideFoods.maduro:
                TotalCost += 4f * NumOfSides;
                MealName += NumOfSides + " Platano Maduro";
                SideDescription = "something about Maduros";

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
    public void addCoffee()
    {
        WantsCoffee = true;
    }
    public int getNumOfSides()
    { return NumOfSides; }
    public int getNumOfSides1()
    { return NumOfSides1; }
    public float getFoodCost()
    { return foodsCost; }
    public string getMealName()
    { return ConfirmedMealName; }
    public bool getCoffeeBool()
    { return WantsCoffee; }
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
    Frijoles
}

