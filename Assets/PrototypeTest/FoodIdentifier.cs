using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodIdentifier : MonoBehaviour
{
    public Ingredients.IngredientsNames FoodType;
    private float ResetDelay = 0.5f;
    public bool Usable;

    public void startReset()
    {
        StartCoroutine(reset());
    }
    public IEnumerator reset()
    {
        Usable = true;
        yield return new WaitForSeconds(ResetDelay);
        Usable = false;
    }    
}
