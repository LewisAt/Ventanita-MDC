using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Meal/MealObject")]
//Adds an asset menu which will be used to create prefab asset for orders and customize the orders values.
//Orders will be attach them to the customer. Created Orders uses food identifier enums to be compared to plate identifier enums in grade order script.
public class MealObject : ScriptableObject
{
    public SideFoods sides;
    public MainFoods Mains;
    public bool hasRice = false;
    public bool hasSide = false;
}

