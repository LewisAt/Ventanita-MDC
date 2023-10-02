using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    public SideFoods sides;
    public MainFoods Mains;
    public bool hasRice = false;
    public bool hasSide = false;
    public bool hasCoffee = false;
    //Rice = 0 Coffee = 1 Croqueta = 2 Tostone = 3 Maduro = 4 Rabo = 5 Fricase = 6
    public int foodsCost;

    private void Awake()
    {
        
        print(sides);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            
            print(sides);
        }
    }
    
}
public enum SideFoods
{
    croqueta,
    tostone,
    maduro
}
public enum MainFoods
{
    Rabo,
    Fricase
}

