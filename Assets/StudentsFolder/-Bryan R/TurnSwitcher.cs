using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class TurnSwitcher : MonoBehaviour
{
    public GameObject playerHand;   // Left or Right Hand
    
    // If bool is True then Smooth turn || false then Snap turn
    private bool turnSwitch = false;

    private GameObject TurnController;
    public static TurnSwitcher instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void SmoothTurnAllowed()
    {
        turnSwitch = true;
    }

    public void SnapTurnAllowed()
    {
        turnSwitch = false;
    }

    /*void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        SceneInitialSetup();
        Debug.Log("general manager has been started and the scene has been setup");

    }*/

    private GameObject Turncontroller;
    void findTurnController()
    {
        TurnController = GameObject.Find("XR Player Rig/XR Origin (XR Rig)/Locomotion System/Turn");
        if (TurnController == null)
        {
            Debug.Log("TurnController has not been found");
        }
        else
        {
            Debug.Log("TurnController has been found");
        }
    }

    public void SetTurningOption(bool SmoothTurning)
    {
        turnSwitch = SmoothTurning;
        Debug.Log("SmoothTurning has been toggled and the value is now: " + turnSwitch);
        if (TurnController == null)
        {
            findTurnController();
        }

        if (turnSwitch == true)
        {
            playerHand.GetComponent<ActionBasedControllerManager>().smoothTurnEnabled = true;
        }
        else if (turnSwitch == false)
        {
            playerHand.GetComponent<ActionBasedControllerManager>().smoothTurnEnabled = false;
        }
    }

    void SceneInitialSetup()
    {
        findTurnController();
        SetTurningOption(turnSwitch);
    }
}