using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Meal/MealObject")]

public class MealObject : ScriptableObject
{
    public SideFoods sides;
    public MainFoods Mains;
    public bool hasRice = false;
    public bool hasSide = false;
}

