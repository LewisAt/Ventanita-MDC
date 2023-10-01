using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    public SideFoods sides;
    public MainFoods Mains;
    public bool hasRice = false;
    public bool hasSide = false;

    private void Awake()
    {
        RandomSide();
        print(sides);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            RandomSide();
            print(sides);
        }
    }
    void RandomSide()
    {
        int num = Random.Range(0, 3);
        sides = (SideFoods)num;
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

