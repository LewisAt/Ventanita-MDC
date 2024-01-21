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
    float moneySaved;
    bool difficultySet = false;
    string difficulty;
    int DayCount = 0;
    static bool DirectorExists = false;
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
    public void getDifficulty()
    {
        thisScene = SceneManager.GetActiveScene();
        if (difficultySet == false && thisScene.name == "MainBuil 11-25-23")
        {
            GameObject CustomerWindow;
            CustomerWindow = GameObject.FindGameObjectWithTag("CustomerWindow");
            orders = CustomerWindow.GetComponent<GradeOrderInput>();
            print("Day: " + DayCount);
            setDifficulty();
            difficultySet = true;
        }
    }
    void setDifficulty()
    {
        //Easy
        if (moneySaved < 500)
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
        print(difficulty);
    }
    public void saveMoney(float moneyEarned)
    {
        if (moneySaved < moneyEarned) moneySaved = moneyEarned;
        print("Money Saved: " + moneySaved);
        difficultySet = false;
        
    }
}
