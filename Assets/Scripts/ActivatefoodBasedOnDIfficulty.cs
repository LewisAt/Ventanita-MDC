using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatefoodBasedOnDIfficulty : MonoBehaviour
{
    [Range(0, 4)]
    [SerializeField] private int m_ObjectEnableDifficulty = 0;
    void Start()
    {
        int currentDifficutly = GameManager.instance.CurrentDifficulty;
        if (currentDifficutly >= m_ObjectEnableDifficulty)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }
}
