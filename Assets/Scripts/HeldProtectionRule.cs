using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldProtectionRule : MonoBehaviour
{
    private bool isHeld = false;
    public LaldleIdentifier laldleIdentifier;
    private IEnumerator resetCoroutine;
    public bool IsBeingHeld
    {
        get { return isHeld; }
        set { isHeld = value; }
    }
    public void SetHeld(bool held)
    {
        isHeld = held;
    }
    public void startResetWithDelay()
    {
        resetCoroutine = ResetWithDelay(10);
        StartCoroutine(resetCoroutine);
    }
    private IEnumerator ResetWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        laldleIdentifier.RespawnNow();
    }
    public void StopReset()
    {
        StopCoroutine(resetCoroutine);
    }
    


}
