using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodExplanation : MonoBehaviour
{
    static string tempFood;
    static IngredientUI ingredient;

    private void Start()
    {
        ingredient = GetComponent<IngredientUI>();
        if (ingredient == null) print("it is not working");
    }
    public static void CafeConLeche()
    {
        tempFood = "The cafe con leche drink originated in Spain. After becoming popular in Spain, " +
            "this coffee beverage has spread to other Spanish-speaking countries and area. Cuban " +
            "restaurants in Florida often have walk-up windows (Ventanita) that serve cafe con " +
            "leche. Cafe con leche is considered a breakfast drink in many countries that serve it. " +
            "Because of the milk, it is heavier and more filling than coffee drinks.";
        ingredient.Testing(tempFood);
    }

    public static void RaboEncendido()
    {
        tempFood = "this is just a practice text";
        ingredient.Testing(tempFood);
    }
}
