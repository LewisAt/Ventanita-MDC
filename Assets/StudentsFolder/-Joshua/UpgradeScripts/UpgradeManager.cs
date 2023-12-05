using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject panel;
    
    void Continue()
    {
        panel.SetActive(false);
    }
}
