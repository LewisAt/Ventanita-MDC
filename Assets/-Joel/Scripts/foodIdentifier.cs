using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public foodPosition pos;
    public typesOfFood food;
}
