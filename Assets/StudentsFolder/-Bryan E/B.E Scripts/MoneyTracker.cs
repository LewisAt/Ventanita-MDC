using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoneyTracker : MonoBehaviour
{

    public static float UserCash = 0.00f;
    public TMP_Text currentCash;

    void Update()
    {
        currentCash.text = "Money Earned $" + UserCash.ToString();
    }
}
