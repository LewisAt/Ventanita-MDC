using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodExplanation : MonoBehaviour
{
    static string tempFood;
    static IngredientUI ingredient;

    /*This script contains all the info being displayed on the food info UI when called throught the buttons
     * associated to ingredientUI.*/

    private void Start()
    {
        ingredient = GetComponent<IngredientUI>();
        if (ingredient == null) print("it is not working");
    }
    public static void CafeConLeche()
    {
        tempFood = "Cafe con leche, or Cuban coffee with milk," +
            " is a staple of Cuban culture and cuisine. It is a symbol of " +
            "Cuban hospitality and community, and its rich flavor and comforting" +
            " aroma make it a beloved part of the Cuban daily routine.";
        ingredient.SpawnPanel(tempFood);
    }
    public static void RaboEncendido()
    {
        tempFood = "Rabo Encendido, or Cuban Oxtail Stew, is a beloved and iconic dish in " +
            "Cuban culture, cherished for its rich flavor, cultural significance, and versatility.";
        ingredient.SpawnPanel(tempFood);
    }
    public static void FricasseeDePollo()
    {
        tempFood = "Fricasé de pollo is often served at family gatherings and " +
            "celebrations, and its use of fresh, flavorful ingredients is a reminder" +
            " of the bounty of Cuba's agricultural landscape. It is a dish that brings" +
            " people together and is a source of pride for Cubans.";
        ingredient.SpawnPanel(tempFood);
    }
    public static void Croquetas()
    {
        tempFood = "Croquetas are a beloved and significant part of Cuban culture, " +
            "served at celebrations, as street food, and as part of everyday meals. " +
            "They are a symbol of Cuban identity and heritage, and their versatility " +
            "and deliciousness make them a staple of Cuban cuisine.";
        ingredient.SpawnPanel(tempFood);
    }
    public static void Tostones()
    {
        tempFood = "Tostones are often seen as a symbol of Cuban culture. Tostones are " +
            "often served at family gatherings and celebrations, and they are also a " +
            "popular street food. Tostones are a reminder of Cuba's rich culinary history " +
            "and culture.";
        ingredient.SpawnPanel(tempFood);
    }
    public static void PlatanoMaduros()
    {
        tempFood = "Plátanos maduros are often seen as a symbol of comfort and home " +
            "in Cuba. This is likely due to the fact that plátanos maduros are a staple " +
            "food in Cuba, and they are often associated with childhood memories of " +
            "family meals and celebrations.";
        ingredient.SpawnPanel(tempFood);
    }
    public static void FrijolesNegro()
    {
        tempFood = "Black beans are often seen as a symbol of health, prosperity, and good " +
            "luck in Cuba. This is likely due to the fact that black beans are a nutritious " +
            "food that is available to everyone, regardless of their social status.";
        ingredient.SpawnPanel(tempFood);
    }
    public static void ArrozBlanco()
    {
        tempFood = "White rice is often seen as a symbol of prosperity and abundance " +
            "in Cuba. This is likely due to the fact that rice was once a luxury " +
            "item in Cuba, and it was only available to the wealthy. Today, rice is " +
            "more affordable and accessible to everyone, but it still retains its " +
            "status as a symbol of prosperity.";
        ingredient.SpawnPanel(tempFood);
    }
}
