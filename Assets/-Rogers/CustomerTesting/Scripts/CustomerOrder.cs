using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

//this Script Contains Possible Orders the Customer can make
public class CustomerOrder : MonoBehaviour
{
    public SideFoods sides;
    int NumOfSides;


    public MainFoods Mains;
    public bool hasRice = false;
    bool WantsCoffee = false;
    float foodsCost;
    string MealName;
    string ConfirmedMealName;

    public string MealDescription;


    string riceDescription = "Something about Rice";
    string CoffeeDescription = "Something about Cafe Con Leche";
    string MainDescription = "";
    string SideDescription = "";

    public void randomizeFactors()
    {
        
        //if (sides[0] != SideFoods.None) 
        NumOfSides = Random.Range(0, 4);
        print("Amount of Sides 1: " + NumOfSides);
        WantsCoffee = Random.value < 0.5f;
    }

    public void StartFood()
    {
        float TotalCost = 0;

        if (WantsCoffee) TotalCost += 5f;
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
        switch (sides)
        {
            case SideFoods.None:
                SideDescription = "None";
                break;


            case SideFoods.croqueta:
                TotalCost += 2.5f * NumOfSides;
                MealName += " Y Croquetas ";

                SideDescription = "something about Croquetas";
                break;

            case SideFoods.tostone:
                TotalCost += 3.5f * NumOfSides;
                MealName += " Y Tostones ";
                SideDescription = "something about Tostones";

                break;
            case SideFoods.maduro:
                TotalCost += 4f * NumOfSides;
                MealName += " Y Platano Maduro";
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
    public int getNumOfSides()
    { return NumOfSides; }
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

