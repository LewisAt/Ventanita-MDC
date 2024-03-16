using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    private float MoneySaved = 0.00f;
    private int CurrentDifficulty;

    public static GeneralManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    
    }
    public void SetMoneySaved(float newAmount)
    {
        MoneySaved += newAmount;
    }

}
