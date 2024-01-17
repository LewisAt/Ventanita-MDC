using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Testingbuttons : MonoBehaviour
{
    private Toggle toggle;

    private Transform parent;
    private Image parentImage;
    private Image myImage;

    private ColorBlock toggleColor;
    private Color normal;
    private Color highlight;
    private Color pressed;
    private Color selected;

    private void Start()
    {
        myImage = GetComponent<Image>();

        normal = Color.white;
        highlight = Color.yellow;
        pressed = Color.red;
        selected = Color.green;

        CreateToggle();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        IdentifyFood();
    }

    public void CreateToggle()
    {
        parent = transform.parent;
        if (parent.GetComponent<Image>() != null )
        {
            parentImage = parent.GetComponent<Image>();
        }

        this.AddComponent<Toggle>();
        toggle = GetComponent<Toggle>();
        toggleColor = toggle.colors;
        toggleColor.normalColor = normal;
        toggleColor.highlightedColor = highlight;
        toggleColor.pressedColor = pressed;
        toggleColor.selectedColor = selected;
        toggle.colors = toggleColor;
        toggle.targetGraphic = parentImage;
    }

    public void IdentifyFood()
    {
        if (myImage.sprite.name == "Croquettas")
        {
            toggle.onValueChanged.AddListener(delegate { FoodExplanation.Croquetas(); });
        }
        else if (myImage.sprite.name == "frijoles")
        {
            toggle.onValueChanged.AddListener(delegate { FoodExplanation.FrijolesNegro(); });
        }
        else if (myImage.sprite.name == "fricase_de_pollo")
        {
            toggle.onValueChanged.AddListener(delegate { FoodExplanation.FricasseeDePollo(); });
        }
        else if (myImage.sprite.name == "Maduros")
        {
            toggle.onValueChanged.AddListener(delegate { FoodExplanation.PlatanoMaduros(); });
        }
        else if (myImage.sprite.name == "rabo_encendido")
        {
            toggle.onValueChanged.AddListener(delegate { FoodExplanation.RaboEncendido(); });
        }
        else if (myImage.sprite.name == "arroz")
        {
            toggle.onValueChanged.AddListener(delegate { FoodExplanation.ArrozBlanco(); });
        }
        else if (myImage.sprite.name == "tostones")
        {
            toggle.onValueChanged.AddListener(delegate { FoodExplanation.Tostones(); });
        }
    }
}
