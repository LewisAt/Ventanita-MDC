using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaldleIdentifier : MonoBehaviour
{
    //Identifies the ladle in code. Makes it accessible by other scripts;
    //Was going to be used in case we were gonna have different ladle's for each food object.
    public enum TypeOfLaldle
    {
        general,
        tostone,
        croqueta,
        maduro,
        Fricase,
        Rabo,
        Beans,
        Arroz
    }

    public TypeOfLaldle typeOfLaldle;
}
