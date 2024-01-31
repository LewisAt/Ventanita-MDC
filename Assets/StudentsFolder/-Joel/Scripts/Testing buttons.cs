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

    private bool check;

    public int numOfListners = 0;
    private ColorBlock toggleColor;
    private Color normal;
    private Color highlight;
    private Color pressed;
    private Color selected;

    private void Start()
    {
        myImage = GetComponent<Image>();
        check = false;
        normal = Color.white;
        highlight = Color.yellow;
        pressed = Color.red;
        selected = Color.green;

        CreateToggle();
    }
    // Update is called once per frame
    void Update()
    {
        print(numOfListners);
        if (myImage.sprite != null && check == false)
        {
            IdentifySlot();
            check = true;
        }
        else if (myImage.sprite == null && true)
        {
            toggle.onValueChanged.RemoveAllListeners();
            check = false;
        }
    }

    public void CreateToggle()
    {
        parent = transform.parent;
        if (parent.GetComponent<Image>() != null)
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

    public void IdentifySlot()
    {

        print("Identify slot function is calling");
        if (gameObject.tag == "slot1")
        {
            Slot1();
        }
        else if (gameObject.tag == "slot2")
        {
            Slot2();
        }
        else if (gameObject.tag == "slot3" || gameObject.tag == "slot4")
        {
            Slot3();
        }

    }

    void Slot1()
    {
        print("slot 1 is calling");
        if (myImage.sprite.name == "arroz")
        {
            toggle.onValueChanged.AddListener(delegate { FoodExplanation.ArrozBlanco(); });
            numOfListners++;
        }
    }

    void Slot2()
    {
        print("slot 2 is calling");
        if (myImage.sprite.name == "frijoles")
        {
            toggle.onValueChanged.AddListener(delegate { FoodExplanation.FrijolesNegro(); });
            numOfListners++;
        }
        else if (myImage.sprite.name == "fricase_de_pollo")
        {
            toggle.onValueChanged.AddListener(delegate { FoodExplanation.FricasseeDePollo(); });
            numOfListners++;
        }
        else if (myImage.sprite.name == "rabo_encendido")
        {
            toggle.onValueChanged.AddListener(delegate { FoodExplanation.RaboEncendido(); });
            numOfListners++;
        }

    }

    void Slot3()
    {
        print("slot 3 is calling");

        if (myImage.sprite.name == "Croquettas")
        {
            toggle.onValueChanged.AddListener(delegate { FoodExplanation.Croquetas(); });
            numOfListners++;
        }
        else if (myImage.sprite.name == "Maduros")
        {
            toggle.onValueChanged.AddListener(delegate { FoodExplanation.PlatanoMaduros(); });
            numOfListners++;
        }
        else if (myImage.sprite.name == "tostones")
        {
            toggle.onValueChanged.AddListener(delegate { FoodExplanation.Tostones(); });
            numOfListners++;
        }
    }
}

