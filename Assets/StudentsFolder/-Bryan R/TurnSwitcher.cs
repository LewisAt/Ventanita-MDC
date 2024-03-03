using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TurnSwitcher : MonoBehaviour
{
    public GameObject playerXROrigin;

    // If bool is True then Smooth turn || false then Snap turn
    private static bool turnSwitch;


    void Update()
    {
        if (turnSwitch == true)
        {
            playerXROrigin.GetComponent<ActionBasedSnapTurnProvider>().enabled = false;
            playerXROrigin.GetComponent<ActionBasedContinuousMoveProvider>().enabled = true;
        }
        else if (turnSwitch == false)
        {
            playerXROrigin.GetComponent<ActionBasedSnapTurnProvider>().enabled = true;
            playerXROrigin.GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
        }
    }

    public void SmoothTurnAllowed()
    {
        turnSwitch = true;
        /*playerXROrigin.GetComponent<ActionBasedSnapTurnProvider>().enabled = false;
        playerXROrigin.GetComponent<ActionBasedContinuousMoveProvider>().enabled = true;*/
    }

    public void SnapTurnAllowed()
    {
        turnSwitch = false;
        /*playerXROrigin.GetComponent<ActionBasedSnapTurnProvider>().enabled = true;
        playerXROrigin.GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;*/
    }
}
