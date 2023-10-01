
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Changed enums to global
//*problem* Customer


public class foodIdentifier : MonoBehaviour
{
    public enum typesOfFood
    {
        croqueta,
        tostone,
        maduro,
        FraseDePollo,
        Rabo,
        Beans
    }
    public enum foodPosition
    {
        main,
        side
    }
    public typesOfFood food;
    
    public foodPosition pos;
    

    
}
