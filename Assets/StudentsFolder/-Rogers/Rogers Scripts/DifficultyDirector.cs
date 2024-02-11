using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyDirector : MonoBehaviour
{
    Scene thisScene;
    GradeOrderInput orders;
    public CustomerOrder[] EasyOptions;
    public CustomerOrder[] MediumOptions;
    public CustomerOrder[] HardOptions;
    float[] DifficultyGoal = { 500, 1000, 1500 };
    int currentDiff = 0;
    bool difficultySet = false;
    static bool DirectorExists = false;
    //Prevents duplicate instances of itself
    protected void Awake()
    {
        if (DirectorExists == true)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
            DirectorExists = true;
        }
    }
    //Gets called by GradeOrderInput on Start
    public void getDifficulty()
    {
        thisScene = SceneManager.GetActiveScene();
        if (difficultySet == false && thisScene.name == "MainBuil 11-25-23")
        {
            GameObject CustomerWindow;
            CustomerWindow = GameObject.FindGameObjectWithTag("CustomerWindow");
            orders = CustomerWindow.GetComponent<GradeOrderInput>();
            setDifficulty();
            difficultySet = true;
        }
    }
    //Gives Grade Order its difficulty depending on its difficult increment
    void setDifficulty()
    {
        //Easy
        switch (currentDiff)
        {
            case 0: //Easy
                orders.possibleOrders = new CustomerOrder[EasyOptions.Length];
                orders.possibleOrders = EasyOptions;
                break;
            case 1: //Medium
                orders.possibleOrders = new CustomerOrder[MediumOptions.Length];
                orders.possibleOrders = MediumOptions;
                break;
            case 2: //Hard
                orders.possibleOrders = new CustomerOrder[HardOptions.Length];
                orders.possibleOrders = HardOptions;
                break;
                /*
                if (currentDiff)
                {
                    orders.possibleOrders = new CustomerOrder[EasyOptions.Length]; 
                    orders.possibleOrders = EasyOptions;
                    difficulty = "Easy";
                }
                //Medium
                else if(moneySaved < 1000 && moneySaved >= 500)
                {
                    orders.possibleOrders = new CustomerOrder[MediumOptions.Length];
                    orders.possibleOrders = MediumOptions;
                    difficulty = "Medium";
                }
                //Hard
                else if(moneySaved >= 1000)
                {
                    orders.possibleOrders = new CustomerOrder[HardOptions.Length];
                    orders.possibleOrders = HardOptions;
                    difficulty = "Hard";
                }
                */
        }
    }
    //Subtracts the money you earned after level and when difficults goal reaches zero higher the difficulty
    public void saveMoney(float moneyEarned)
    {
        DifficultyGoal[currentDiff] = DifficultyGoal[currentDiff] - moneyEarned;
        if (DifficultyGoal[currentDiff] <= 0 && currentDiff != 2) 
        {
            currentDiff++;
        }
        
        difficultySet = false;
        
    }
}
