using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order_UI : MonoBehaviour
{
    //Between the two greens is just for testing and will be deleted
    public int main_food = 1;
    public int side1_food = 4;
    public int side2_food = 3;
    //End

    [SerializeField] private GameObject main_filter;
    [SerializeField] private GameObject side1_filter;
    [SerializeField] private GameObject side2_filter;

    [SerializeField] private Material arroz;
    [SerializeField] private Material arroz_con_frijoles;
    [SerializeField] private Material cafe_con_leche;
    [SerializeField] private Material cafe_negra;
    [SerializeField] private Material chicken;
    [SerializeField] private Material croquettas;
    [SerializeField] private Material frijoles;
    [SerializeField] private Material maduros;
    [SerializeField] private Material rabo_encendido;
    [SerializeField] private Material tostones;

    void Start()
    {
        main_UI();
        side1_UI();
        side2_UI();
    }

    public void main_UI()
    {
        if (main_food == 0)
        {
            main_filter.GetComponent<Renderer>().material = chicken;
        }
        else if (main_food == 1)
        {
            main_filter.GetComponent<Renderer>().material = rabo_encendido;
        }
    }

    public void side1_UI()
    {
        if (side1_food == 0)
        {
            side1_filter.GetComponent<Renderer>().material = arroz;
        }
        else if (side1_food == 1)
        {
            side1_filter.GetComponent<Renderer>().material = frijoles;
        }
        else if (side1_food == 2)
        {
            side1_filter.GetComponent<Renderer>().material = cafe_con_leche;
        }
        else if (side1_food == 3)
        {
            side1_filter.GetComponent<Renderer>().material = cafe_negra;
        }
        else if (side1_food == 4)
        {
            side1_filter.GetComponent<Renderer>().material = croquettas;
        }
        else if (side1_food == 5)
        {
            side1_filter.GetComponent<Renderer>().material = maduros;
        }
        else if (side1_food == 6)
        {
            side1_filter.GetComponent<Renderer>().material = tostones;
        }
    }

    public void side2_UI()
    {
        if (side2_food == 0)
        {
            side2_filter.GetComponent<Renderer>().material = arroz;
        }
        else if (side2_food == 1)
        {
            side2_filter.GetComponent<Renderer>().material = frijoles;
        }
        else if (side2_food == 2)
        {
            side2_filter.GetComponent<Renderer>().material = cafe_con_leche;
        }
        else if (side2_food == 3)
        {
            side2_filter.GetComponent<Renderer>().material = cafe_negra;
        }
        else if (side2_food == 4)
        {
            side2_filter.GetComponent<Renderer>().material = croquettas;
        }
        else if (side2_food == 5)
        {
            side2_filter.GetComponent<Renderer>().material = maduros;
        }
        else if (side2_food == 6)
        {
            side2_filter.GetComponent<Renderer>().material = tostones;
        }
    }
}
