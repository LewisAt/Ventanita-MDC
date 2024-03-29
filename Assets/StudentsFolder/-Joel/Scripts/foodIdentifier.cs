
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Joel Figueroa
//This scripts functionality is just for enums. Used by attaching this script to the food objects so they are
//identifiable by other scripts and accessible.

//UPDATE: This script was modified by Rogers.
//Changed enums to global
public class foodIdentifier : MonoBehaviour
{

    public enum typesOfFood
    {
        croqueta,
        tostone,
        maduro,
        Arroz,
        Beans,
        Fricase,
        Rabo
    }
    public enum foodPosition
    {
        main = 0,
        side = 1
    }
    public typesOfFood food;
    
    public foodPosition pos;
    

    
}
