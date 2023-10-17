using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IngredientUI : MonoBehaviour
{
    public GameObject foodPanel;
    public TextMeshProUGUI foodInfo;
    bool buttonPressed = false;
    bool textShowing = false;
    public void Testing(string foodExplanation)
    {
        if (buttonPressed == true)
        {
            if (textShowing == true)
            {
                print("button was pressed and showing information");
                foodInfo.text = foodExplanation;
                textShowing = false;
            }
            else
            {
                print("button not pressed");
                foodPanel.SetActive(false);
                buttonPressed = false;
                foodInfo.text = null;
            }
        }
        else
        {
            print("button pressed");
            foodPanel.SetActive(true);
            buttonPressed = true;
            foodInfo.text = foodExplanation;
            textShowing = true;
        }
    }
}
