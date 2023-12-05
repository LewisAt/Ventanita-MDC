using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Burning : MonoBehaviour
{
    GameObject textParent;
    GameObject cookedInstance;
    TMP_Text displayedText;
    Rigidbody rb;
    Coroutine lastCoroutine;

    int whenCookingEnds;
    int timePassing = 0;
    bool isCooking;

    void Update()
    {

        if (isCooking)
        {
            float timeText = 100 - ((whenCookingEnds - timePassing) * 100 / whenCookingEnds);
            displayedText.text = "" + timeText + "%";
        }
    }

    public void startCooking(GameObject foodTxt, GameObject finishedProduct, int cookingTimeEnds)
    {
        rb = this.GetComponent<Rigidbody>();
        textParent = Instantiate(foodTxt, this.transform.position, Quaternion.identity);
        displayedText = textParent.GetComponentInChildren<TMP_Text>();
        cookedInstance = finishedProduct;
        whenCookingEnds = cookingTimeEnds;
        
        lastCoroutine = StartCoroutine("cookTime");
    }
    IEnumerator cookTime()
    {
        this.transform.rotation = Quaternion.identity;
        isCooking = true;
        while (timePassing < whenCookingEnds)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            yield return new WaitForSeconds(1);
            timePassing++;
        }
        GetCooked();
    }
    void GetCooked()
    {
        Instantiate(cookedInstance, this.transform.position, Quaternion.identity);
        isCooking = false;
        Destroy(textParent);
        Destroy(this.gameObject);
        StopCoroutine(getLastCoroutine());
    }
    public void foodReset()
    {
        rb.constraints = RigidbodyConstraints.None;
        Destroy(textParent);
        StopCoroutine(getLastCoroutine());
    }
    public Coroutine getLastCoroutine()
    {  return  lastCoroutine; }
}
