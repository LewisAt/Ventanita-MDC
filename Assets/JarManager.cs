using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JarManager : MonoBehaviour
{
    //Set this to the jar text component in the jar canvas
    public Text moneyText;

    //Drag the object containing the money tracker in here
    public GameObject moneyTracker;

    //Set the gameobjects containing the models of the different jar phases. They are children of the Jar GameObject
    public GameObject phase1Jar;
    public GameObject phase2Jar;
    public GameObject phase3Jar;
    public GameObject phase4Jar;

    //Set at what amount do you want the different phases to trigger
    public float phase2Limit;
    public float phase3Limit;
    public float phase4Limit;

    private float moneyEarned;

    private void Update()
    {
        moneyEarned = moneyTracker.GetComponent<MoneyTracker>().totalMoney;
        moneyText.text = "Total Tips Earned: " + moneyEarned.ToString();

        if (moneyEarned >= phase4Limit)
        {
            phase1Jar.SetActive(false);
            phase2Jar.SetActive(false);
            phase3Jar.SetActive(false);
            phase4Jar.SetActive(true);
        }
        else if (moneyEarned >= phase3Limit)
        {
            phase1Jar.SetActive(false);
            phase2Jar.SetActive(false);
            phase3Jar.SetActive(true);
            phase4Jar.SetActive(false);
        }
        else if (moneyEarned >= phase2Limit)
        {
            phase1Jar.SetActive(false);
            phase2Jar.SetActive(true);
            phase3Jar.SetActive(false);
            phase4Jar.SetActive(false);
        }
        else
        {
            phase1Jar.SetActive(true);
            phase2Jar.SetActive(false);
            phase3Jar.SetActive(false);
            phase4Jar.SetActive(false);
        }
    }
}
