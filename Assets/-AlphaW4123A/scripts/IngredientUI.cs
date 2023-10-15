using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class IngredientUI : MonoBehaviour
{
    public GameObject foodPanel;
    public TextMeshProUGUI foodInfo;
    bool buttonPressed = false;
    public void Testing()
    {
        if (buttonPressed == true)
        {
            print("button pressed");
            foodPanel.SetActive(false);
            buttonPressed = false;
        }
        else
        {
            print("button not pressed");
            foodPanel.SetActive(true);
            buttonPressed = true;
        }
    }

    public void Start()
    {
        foodPanel.SetActive(false);
    }
}
