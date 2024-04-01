using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyDirector : MonoBehaviour
{

    GradeOrderInput PossibleOrderScript;
    [SerializeField] private CustomerOrder[] EasyOptions;
    [SerializeField] private CustomerOrder[] SemiMediumOptions;

    [SerializeField] private CustomerOrder[] MediumOptions;
    [SerializeField] private CustomerOrder[] SemiHardOptions;

    [SerializeField] private CustomerOrder[] HardOptions;
    //Prevents duplicate instances of itself
    //Gets called by GradeOrderInput on Start

    private void Start() 
    {
        PossibleOrderScript = GameObject.FindGameObjectWithTag("CustomerWindow").GetComponent<GradeOrderInput>();
        setFoodsForDifficulty();
    }
    private void setFoodsForDifficulty()
    {
        //Sets the difficulty of the game
        int currentDifficutly = GameManager.instance.CurrentDifficulty;
        switch (currentDifficutly)
        {
            case 0:
                PossibleOrderScript.possibleOrders = EasyOptions;
                break;
            case 1:
                PossibleOrderScript.possibleOrders = SemiMediumOptions;
                PossibleOrderScript.DecreaseTimer(5);
                break;
            case 2:
                PossibleOrderScript.possibleOrders = MediumOptions;
                PossibleOrderScript.DecreaseTimer(10);
                break;
            case 3:
                PossibleOrderScript.possibleOrders = SemiHardOptions;
                PossibleOrderScript.DecreaseTimer(15);
                break;
            case 4:
                PossibleOrderScript.possibleOrders = HardOptions;
                break;
            case 5:
                PossibleOrderScript.possibleOrders = HardOptions;

                PossibleOrderScript.DecreaseTimer(20);
                break;
            default:
                PossibleOrderScript.possibleOrders = EasyOptions;
                break;
        }
    }

}
