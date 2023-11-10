using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTracker : MonoBehaviour
{
    public static float UserCash = 0.00f;
    public Text currentCash;

    void Update()
    {
        currentCash.text = UserCash.ToString() + "$";
    }
}
