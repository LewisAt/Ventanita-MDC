using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This is only a layout. Once I get the models of the food and findout how to change prefabs on script,
//this script will change to compensate and will be added on Bryan Movement Script.

public class Randomizer_Test : MonoBehaviour
{
    int randnum;
    string mfoodtype = "";
    string sfoodtype1 = "";
    string sfoodtype2 = "";

    void Start()
    {
        Randomizer();
    }

    void Randomizer()
    {
        for (int i = 0; i < 3; i++)
        {
            if(i == 0)
            {
                mfoodtype = mRandomizer();
            }
            else if(i == 1)
            {
                sfoodtype1 = sRandomizer();
            }
            else
            {
                sfoodtype2 = sRandomizer();
            }
        }

        if (sfoodtype1 == sfoodtype2)
            Debug.Log("Hi, can I have " + mfoodtype + " with double " + sfoodtype1);

        else
            Debug.Log("Hi, can I have " + mfoodtype + " with " + sfoodtype1 + " and " + sfoodtype2);
    }

    string mRandomizer()
    {
        randnum = Random.Range(0, 2);
        if (randnum == 0)
        {
            mfoodtype = "Rabo Encendide";
        }
        else if (randnum == 1)
        {
            mfoodtype = "Fricase de Pollo";
        }
        return mfoodtype;
    }

    string sRandomizer()
    {
        string sfoodtype;
        randnum = Random.Range(0, 6);
        if (randnum == 0)
        {
            sfoodtype = "Black Beans";
        }
        else if (randnum == 1)
        {
            sfoodtype = "White Rice";
        }
        else if (randnum == 2)
        {
            sfoodtype = "Croquetas";
        }
        else if (randnum == 3)
        {
            sfoodtype = "Tostones";
        }
        else if (randnum == 4)
        {
            sfoodtype = "Platano Maduros";
        }
        else
        {
            sfoodtype = "Cafe con Leche";
        }
        return sfoodtype;
    }
}
