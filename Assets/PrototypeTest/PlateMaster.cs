using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class PlateMaster : MonoBehaviour
{
    [HideInInspector] public bool[] FoodBool;
    private bool isEmpty;
    // the bool is suppose to line up with ingredients in enum so 0 = rice 1 = Lechon

    public Plate[] AllCombinations;
    public Text whatisit;
    public Text Currentfood;
    public GameObject PlatemodeLocaiton;
    private GameObject emptyPlate;
    private GameObject ObjectToDelete;
    private GameObject[] AttachedObjects;
    [HideInInspector] public int Tostones;

    [HideInInspector] public int Maduros;

    // this is an array of all the plate formantions
    private void Start()
    {
        FoodBool = new bool[8];
        isEmpty = true;
        AttachedObjects = new GameObject[6];
        ObjectToDelete = PlatemodeLocaiton.transform.GetChild(0).gameObject;
    }

    public void OnTriggerStay(Collider other)
    {
        FoodIdentifier currentfood = other.GetComponent<FoodIdentifier>();
        if(other.gameObject.tag != "Food")
        {
            return;
        }    
        if(currentfood.Usable)
        {
            UpdateFood(other.gameObject);
            emptyPlate = AllCombinations[3].plateLook;
        }
    }

    void checkStats()
    {
        for(int i = 0; i < AllCombinations.Length; i++)
        {
            Plate currentPlater = AllCombinations[i];
            for(int o = 0; o < currentPlater.foods.Length; o++)
            {
                if (FoodBool[0] != currentPlater.foods[0])
                {
                    break;

                }
                if (FoodBool[1] != currentPlater.foods[1])
                {

                    break;
                }
                if (FoodBool[2] != currentPlater.foods[2])
                {

                    break;
                }
                if (FoodBool[3] != currentPlater.foods[3])
                {

                    break;
                }
                UpdateModel(currentPlater.plateLook);
                return;

            }

        }
        
    }
    public Plate RequestStats()
    {
        for (int i = 0; i < AllCombinations.Length; i++)
        {
            Plate currentPlater = AllCombinations[i];
            for (int o = 0; o < currentPlater.foods.Length; o++)
            {
                if (FoodBool[0] != currentPlater.foods[0])
                {
                    break;

                }
                if (FoodBool[1] != currentPlater.foods[1])
                {

                    break;
                }
                if (FoodBool[2] != currentPlater.foods[2])
                {

                    break;
                }
                if (FoodBool[3] != currentPlater.foods[3])
                {

                    break;
                }

                return currentPlater;
            }

        }
        return null;
    }
    public void attachSide(GameObject foodToAttach)
    { 
        Destroy(foodToAttach.GetComponent<XRGrabInteractable>());
        Destroy(foodToAttach.GetComponent<Rigidbody>());
        Destroy(foodToAttach.GetComponent<FoodIdentifier>());
        Destroy(foodToAttach.GetComponent<BoxCollider>());
        foodToAttach.transform.parent = this.gameObject.transform;
        for (int i = 0; i < AttachedObjects.Length; i++)
        {
            if(AttachedObjects[i] == null)
            {
                AttachedObjects[i] = foodToAttach;
                return;
            }
        }    



    }
    public void UpdateFood(GameObject other)
    {
        
        if (other.gameObject.tag == "Food")
        {
            GameObject food = other.gameObject;
            FoodIdentifier ingredient = food.GetComponent<FoodIdentifier>();
            isEmpty = false;
            if (ingredient.FoodType == Ingredients.IngredientsNames.Maduros)
            {
                if (Maduros < 3)
                {
                    Maduros++;
                    attachSide(food);
                    Debug.Log("Maduros is " + Maduros);
                    return;

                }
            }
            if (ingredient.FoodType == Ingredients.IngredientsNames.Tostones)
            {
                if (Tostones < 3)
                {
                    Tostones++;
                    attachSide(food);
                    Debug.Log("Tostones is " + Tostones);
                    return;
                }
            }
            if (FoodBool[(int)ingredient.FoodType])
            {
                return;

                //this checks if the bool for the same type of food is here already. If so don't add it and add some code for telling the player that.
            }
            else if (FoodBool[1] && (int)ingredient.FoodType == 2)
            {
                return;
                // this checks if we already have Lechon if we do we can't add Frecase
            }
            else if (FoodBool[2] && (int)ingredient.FoodType == 1)
            {
                return;
                //this checks if we already have Frecase if we do we can't add Lechon
            }
            else if (FoodBool[0] && (int)ingredient.FoodType == 3)
            {
                return;
                // this checks if we already have Lechon if we do we can't add Frecase
            }
            else if (FoodBool[3] && (int)ingredient.FoodType == 0)
            {
                return;
                //this checks if we already have Frecase if we do we can't add Lechon
            }

            FoodBool[(int)ingredient.FoodType] = true;
            Destroy(food);
            checkStats();

        }
    }
    public void ClearPlate()
    {
        if(isEmpty == false)
        {
            for (int i = 0; i < FoodBool.Length; i++)
            {
                FoodBool[i] = false;

            }
            for (int i = 0; i < AttachedObjects.Length; i++)
            {
                Destroy(AttachedObjects[i]);
            }
            Maduros = 0;
            Tostones = 0;
            isEmpty = true;
            UpdateModel(emptyPlate);
            whatisit.text = Maduros.ToString();
            Currentfood.text = "No food";
        }
        
    }
    public void isPlateCleared()
    {
        for (int i = 0; i < FoodBool.Length; i++)
        {
            if(FoodBool[i])
            {

                return;
            }
        }
    }
    public void UpdateModel(GameObject Newmodel)
    {
        Destroy(ObjectToDelete);
        GameObject spawned = Instantiate(Newmodel);
        ObjectToDelete = spawned;
        spawned.transform.SetParent(PlatemodeLocaiton.transform);
        spawned.transform.localRotation = PlatemodeLocaiton.transform.localRotation;
        spawned.transform.localPosition = PlatemodeLocaiton.transform.localPosition;

    }
}
