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
    string prevText;
    public void SpawnPanel(string foodExplanation)
    {
        prevText = foodExplanation;
        if (foodPanel.activeInHierarchy)
        {
            if (foodInfo.text == prevText)
            {
                foodPanel.SetActive(false);
            }
            else
            {
                foodInfo.text = prevText;
            }
            
        }
        else if (!foodPanel.activeInHierarchy)
        {
            foodPanel.SetActive(true);
            foodInfo.text = foodExplanation;
        }
    }
}
