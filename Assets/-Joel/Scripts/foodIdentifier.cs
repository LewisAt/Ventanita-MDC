
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Changed enums to global
public enum typesOfFood
{
    croqueta,
    tostone,
    maduro,
    FraseDePollo,
    Rabo,
    Beans
};
public enum foodPosition
{
    main,
    side
}

public class foodIdentifier : MonoBehaviour
{

    public typesOfFood food;
    
    public foodPosition pos;
    

    
}
