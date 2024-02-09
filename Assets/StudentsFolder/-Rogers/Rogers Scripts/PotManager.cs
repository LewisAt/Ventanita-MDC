using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PotManager : MonoBehaviour
{
    GameObject food;
    Collider foodCollider;
    public GameObject[] cookableResults;
    public GameObject[] cookableRawFood;
    GameObject cookingResult;
    MeshRenderer thisMeshRend;
    public MeshRenderer cookingMeshRend;
    public Mesh restState;
    rawPlaceHolder[] cookableRawScripts;
    rawPlaceHolder collidedFoodScript;
    Coroutine lastCoroutine;
    bool isCooking;
    public Slider cookProgSlider;

    int timePassed = 0;
    int upgradedCookTime;
    public int defaultCookTime;
    int confirmedCookTime;


    // Start is called before the first frame update
    void Start()
    {
        thisMeshRend = GetComponent<MeshRenderer>();
        addScripts();
        if (upgradedCookTime == 0) confirmedCookTime = defaultCookTime;
        else confirmedCookTime = upgradedCookTime;
        cookProgSlider.maxValue = confirmedCookTime;
        cookProgSlider.enabled = false;
        cookingMeshRend.enabled = false;
        cookProgSlider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isCooking) 
        {
            cookProgSlider.value = timePassed;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        bool HasRaw;
        if (collision.gameObject.GetComponent<rawPlaceHolder>() != null)
        {
            collidedFoodScript = collision.gameObject.GetComponent<rawPlaceHolder>();
            HasRaw = true;
        }
        else HasRaw = false;
        if (collision.gameObject.tag == "food" && HasRaw && !isCooking)
        {
            if (isCookable())
            {
                food = collision.gameObject;
                food.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                foodCollider = food.GetComponent<Collider>();

                foodCollider.enabled = false;
                thisMeshRend.enabled = false;
                cookingMeshRend.enabled=true;
                isCooking = true;
                cookProgSlider.gameObject.SetActive(true);
                lastCoroutine = StartCoroutine("boil");
            }
        }
    }
    bool isCookable()
    {
        for (int i = 0; i < cookableRawFood.Length; i++)
        {
            if (collidedFoodScript.rawFood == cookableRawScripts[i].rawFood)
            {
                cookingResult = cookableResults[i];
                return true;
            }
        }
        return false;
    }
    void addScripts()
    {
        cookableRawScripts = new rawPlaceHolder[cookableRawFood.Length];
        for (int i = 0; i < cookableRawFood.Length; i++)
        {
            cookableRawScripts[i] = cookableRawFood[i].GetComponent<rawPlaceHolder>();
        }
    }

    IEnumerator boil()
    {
        while(timePassed < confirmedCookTime)
        {
            yield return new WaitForSeconds(1);
            timePassed++;
        }
        thisMeshRend.enabled = true;
        cookingMeshRend.enabled = false;
        isCooking = false;
        getBoiled();
    }
    void getBoiled()
    {
        GameObject cookedFood;
        cookedFood = Instantiate(cookingResult, food.transform.position, Quaternion.identity);
        cookedFood.AddComponent<DestroyOnPickup>();
        StopCoroutine(lastCoroutine);
        cookProgSlider.gameObject.SetActive(false);
        Destroy(food);

    }
}
