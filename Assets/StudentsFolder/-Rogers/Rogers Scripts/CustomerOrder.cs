using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//this Script uses enum from possible orders created from the meal object script to create the name of the order
//it also randomizes the amount side 1 and side 2 will have
//! right now the script returns a very large value
public class CustomerOrder : MonoBehaviour
{
    public SideFoods sides;
    public SideFoods sides1;
    int NumOfSides;
    int NumOfSides1;


    public MainFoods Mains;
    public bool hasRice = false;
    //bool WantsCoffee;
    [HideInInspector]

    public float foodsCost;
    public float TotalCost = 0;
    string MealName;
    //Get this one for the ui
    [HideInInspector]
    public float foodsCostForCustomer;
    public string ConfirmedMealName;
    public string rice;
    public string main;
    public string side1;
    public string side2;

    public string MealDescription;



    //string riceDescription = "Something about Rice";
    //string CoffeeDescription = "Something about Cafe Con Leche";
    string MainDescription = "";
    string SideDescription = "";

    public void randomizeFactors() //This function checks if there is side 1 and 2 and then randomizes it between 1-3
    {

        if (sides != SideFoods.None)
        {
            NumOfSides = Random.Range(1, 3);
        }
        else
            NumOfSides = 0;

        if (sides1 != SideFoods.None)
        {
            NumOfSides1 = Random.Range(1, 3);
        }
        else
            NumOfSides1 = 0;
        //coffee not yet added
        //WantsCoffee = Random.value < 0.5f;
    }

    public void StartFood() //uses enum to create the order's name with its number of sides and calculate its cost
    {
        //coffee not yet added
        /*
        if (WantsCoffee)
        {
            TotalCost += 5f;
            MealName += "Cafe ";
        }
        if (WantsCoffee && hasRice)
        {
            MealName += "y ";
        }
        */
        TotalCost = 0;
        if (hasRice)
        {
            TotalCost += 1.5f;
            MealName += "Arroz ";
            rice = "Arroz ";
            Debug.Log("Added 1.5 to TotalCost. TotalCost: " + TotalCost);
        }
        else
        {
            rice = "";
        }

        if (hasRice && Mains != MainFoods.None)
        {
            MealName += "Con ";
        }

        switch (Mains)
        {
            case MainFoods.None:
                MainDescription = "None";
                main = "";
                break;
            case MainFoods.Rabo:
                TotalCost += 2.50f;
                MealName += "Rabo Encendido";
                MainDescription = "something about Rabo";
                main = "Rabo Encendido";
                Debug.Log("Added 2.50 to TotalCost. TotalCost: " + TotalCost);
                Debug.Log("Selected main: Rabo Encendido");
                break;
            case MainFoods.Fricase:
                TotalCost += 2.50f;
                MealName += "Fricase de Pollo";
                MainDescription = "something about Fricase";
                main = "Fricase de Pollo";
                Debug.Log("Added 2.50 to TotalCost. TotalCost: " + TotalCost);
                Debug.Log("Selected main: Fricase de Pollo");
                break;
            case MainFoods.Beans:
                TotalCost += 1.00f;
                MealName += "Frijoles";
                MainDescription = "something about Frijoles";
                main = "Frijoles";
                Debug.Log("Added 1.00 to TotalCost. TotalCost: " + TotalCost);
                Debug.Log("Selected main: Frijoles");
                break;
        }

        if (sides != SideFoods.None)
        {
            if (/*WantsCoffee == true ||*/ hasRice == true || Mains != MainFoods.None)
            {
                MealName += " Y ";
            }
        }

        switch (sides)
        {
            case SideFoods.None:
                side1 = "";
                break;
            case SideFoods.croqueta:
                TotalCost += 0.5f * NumOfSides;
                MealName += NumOfSides + " Croquetas ";
                side1 = NumOfSides + " Croquetas ";
                Debug.Log("Added " + (0.5f * NumOfSides) + " to TotalCost. TotalCost: " + TotalCost);
                Debug.Log("Selected side 1: Croquetas");
                break;
            case SideFoods.tostone:
                TotalCost += 0.75f * NumOfSides;
                MealName += NumOfSides + " Tostones ";
                side1 = NumOfSides + " Tostones ";
                Debug.Log("Added " + (0.75f * NumOfSides) + " to TotalCost. TotalCost: " + TotalCost);
                Debug.Log("Selected side 1: Tostones");
                break;
            case SideFoods.maduro:
                TotalCost += 0.75f * NumOfSides;
                MealName += NumOfSides + " Platano Maduro";
                side1 = NumOfSides + " Platano Maduro";
                Debug.Log("Added " + (0.75f * NumOfSides) + " to TotalCost. TotalCost: " + TotalCost);
                Debug.Log("Selected side 1: Platano Maduro");
                break;
        }

        if (sides1 != SideFoods.None)
        {
            MealName += " Y ";
        }

        switch (sides1)
        {
            case SideFoods.None:
                side2 = "";
                break;
            case SideFoods.croqueta:
                TotalCost += 0.5f * NumOfSides;
                MealName += NumOfSides + " Croquetas ";
                side1 = NumOfSides + " Croquetas ";
                Debug.Log("Added " + (0.5f * NumOfSides) + " to TotalCost. TotalCost: " + TotalCost);
                Debug.Log("Selected side 2: Croquetas");
                break;
            case SideFoods.tostone:
                TotalCost += 0.75f * NumOfSides;
                MealName += NumOfSides + " Tostones ";
                side1 = NumOfSides + " Tostones ";
                Debug.Log("Added " + (0.75f * NumOfSides) + " to TotalCost. TotalCost: " + TotalCost);
                Debug.Log("Selected side 2: Tostones");
                break;
            case SideFoods.maduro:
                TotalCost += 0.75f * NumOfSides;
                MealName += NumOfSides + " Platano Maduro";
                side1 = NumOfSides + " Platano Maduro";
                Debug.Log("Added " + (0.75f * NumOfSides) + " to TotalCost. TotalCost: " + TotalCost);
                Debug.Log("Selected side 2: Platano Maduro");
                break;
        }

        foodsCost = TotalCost;
        foodsCostForCustomer = TotalCost;
        Debug.Log("total cost in the gradeorderinput script: " + foodsCost);
        ConfirmedMealName = MealName;
        MealName = "";
    }
    public void addNumOfSides()
    {
        NumOfSides++;
    }
    /*
    public void addCoffee()
    {
        WantsCoffee = true;
    }
    public bool getCoffeeBool()
    { return WantsCoffee; }
    */
    public int getNumOfSides()
    { return NumOfSides; }
    public int getNumOfSides1()
    { return NumOfSides1; }
    public float getFoodCost()
    { return foodsCost; }
    public string getMealName()
    { return ConfirmedMealName; }
    public string getRice()
    { return rice; }
    public string getMain()
    { return main; }
    public string getSide1()
    { return side1; }
    public string getSide2()
    { return side2; }

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
    Beans
}