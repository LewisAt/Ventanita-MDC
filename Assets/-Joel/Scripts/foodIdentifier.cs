using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodIdentifier : MonoBehaviour
{
    public string[] foods = { "food1" , "foods2"};
    
    public enum typesOfFood
    {
        croqueta,
        tostone,
        maduro
    }
    public enum foodPosition
    {
        
        main,
        side
    }
    public foodPosition pos;
    public typesOfFood food;

}
