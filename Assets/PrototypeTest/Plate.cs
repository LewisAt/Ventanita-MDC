using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Meal",menuName = "Meals")]
public class Plate : ScriptableObject
{



    public bool[] foods;
    // this is only data don't change model for it
    public int Cost;
    // this is only data don't change model for it
    public GameObject plateLook;
    public Sprite DishIcon;
    public string DishName;
}
