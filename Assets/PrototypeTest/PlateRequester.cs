using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateRequester : MonoBehaviour
{
    public Plate[] allCombinations;
    private Plate SelectedPlate;
    public Image Display1;
    public Image Display2;
    public Text NameOfDish1;
    public Text NameOfDish2;
    public Text SideTostones1;
    public Text SideTostones2;
    public Text SideMaduros1;
    public Text SideMaduros2;
    private Plate RequestedPlate;
    private GameObject CurrentSelectedPlate;

    private int Tostones;
    private int Maduros;
    public int MoneyEarned;
    public Text MoneyEarnedText;
    public Slider MoneyEarnedSlider;
    public Slider GameTimer1;
    public Slider GameTimer2;

    public Slider FoodTimer1;
    public Slider FoodTimer2;


    public float FoodTimerInSeconds;
    public float GameTimerInSeconds;
    private float FoodSeconds;
    private float GameSeconds;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Plate")
        {
            CurrentSelectedPlate = other.gameObject;
            Debug.Log("I made it to this point");
            checkPlate(other.gameObject);
        }
    }
    private void Start()
    {
        RandomRequest();
        FoodSeconds = FoodTimerInSeconds;
        GameSeconds = GameTimerInSeconds;

    }

    private void Update()
    {
        FoodTimerInSeconds -= Time.deltaTime;
        GameTimerInSeconds -= Time.deltaTime;
        updateTimers();
        if(FoodTimerInSeconds <= 0)
        {
            RandomRequest();
            FoodTimerInSeconds = FoodSeconds;

        }

    }
    private void updateTimers()
    {
        FoodTimer1.value = FoodTimerInSeconds;
        GameTimer1.value = GameTimerInSeconds;
        FoodTimer2.value = FoodTimerInSeconds;
        GameTimer2.value = GameTimerInSeconds;

    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        
    }
    


    void RandomRequest()
    {
        int randomPlate = Random.Range(0, allCombinations.Length);
        SelectedPlate = allCombinations[randomPlate];
        Tostones = Random.Range(0,4);
        Maduros = Random.Range(0, 4);
        UpdateUI();

    }
    void UpdateUI()
    {
        Display1.sprite = SelectedPlate.DishIcon;
        Display2.sprite = SelectedPlate.DishIcon;
        NameOfDish1.text = SelectedPlate.DishName;
        NameOfDish2.text = SelectedPlate.DishName;
        SideTostones1.text = Tostones.ToString();
        SideTostones2.text = Tostones.ToString();

        SideMaduros1.text = Maduros.ToString();
        SideMaduros2.text = Maduros.ToString();
        Debug.Log("Requested Maduros " + Maduros);
        Debug.Log("Requested Tostones " + Tostones);

    }
    void checkPlate(GameObject other)
    {
        PlateMaster currentPlate = other.GetComponent<PlateMaster>();
        Plate Playerplate = currentPlate.RequestStats();
        if(SelectedPlate != Playerplate)
        {
            return;
        }
        if(Maduros != currentPlate.Maduros)
        {
            return;
        }
        if (Tostones != currentPlate.Tostones)
        {
            return;
        }
        Debug.Log("How did you get here?");
        Destroy(CurrentSelectedPlate);
        MoneyEarned += Playerplate.Cost + (Maduros * 3) + (Tostones * 3);
        MoneyEarnedText.text = MoneyEarned.ToString();
        MoneyEarnedSlider.value = MoneyEarned;
        FoodTimerInSeconds = FoodSeconds;
        RandomRequest();
    }
    /*void debug(string info)
    {
        DebugInfo.text = info;
    }*/
}
