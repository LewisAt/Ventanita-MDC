using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Current bugs with this script:
/// - The money saved is not being updated correctly. its delayed
/// 
/// </summary> <summary>
/// 
/// </summary>
public class JarDisplay : MonoBehaviour
{
    /// <summary>
    /// The amount of money currently saved.
    /// </summary>
    private float currentMoneySaved;
    public ParticleSystem JarParticle;
    public TMP_Text JarSavedText;

    private float moneyState0 = 0;
    private float moneyState1 = 10;
    private float moneyState2 = 50;
    private float moneyState3 = 150;
    private float moneyStateLast = 300;
    private bool lazyPlayed = false;
    /// <summary>
    /// Gets or sets the current amount of money saved.
    /// </summary>
    public float m_CurrentMoneySaved
    {
        get { return currentMoneySaved; }
        set
        {
            currentMoneySaved = value;
        }
    }

    void  Start()
    {
        if(GameManager.instance == null)
        {
            Debug.LogError("there is no game manager in the scene.");
            return;
        }
        GameManager.OnMoneySaved += upddateDisplayAmount;
        upddateDisplayAmount();
    }
    void FixedUpdate()
    {
        upddateDisplayAmount();
    }

    public GameObject DisplayState1;
    public GameObject DisplayState2;
    public GameObject DisplayState3;
    public GameObject DisplayStatelast;

    /// <summary>
    /// Updates the display amount based on the current money saved.
    /// </summary>
    void upddateDisplayAmount()
    {
        m_CurrentMoneySaved = GameManager.instance.SaveMoney;
        JarSavedText.text = m_CurrentMoneySaved.ToString();

        if (m_CurrentMoneySaved < moneyState1)
        {
            DisplayState1.SetActive(false);
            DisplayState2.SetActive(false);
            DisplayState3.SetActive(false);
            DisplayStatelast.SetActive(false);
        }
        else if (m_CurrentMoneySaved > moneyState1 && m_CurrentMoneySaved < moneyState2)
        {
            playMoneySFX();
            DisplayState1.SetActive(true);
            DisplayState2.SetActive(false);
            DisplayState3.SetActive(false);
            DisplayStatelast.SetActive(false);
        }
        else if (m_CurrentMoneySaved > moneyState2 && m_CurrentMoneySaved < moneyState3)
        {
            playMoneySFX();
            DisplayState1.SetActive(false);
            DisplayState2.SetActive(true);
            DisplayState3.SetActive(false);
            DisplayStatelast.SetActive(false);
        }
        else if (m_CurrentMoneySaved > moneyState3 && m_CurrentMoneySaved <  moneyStateLast )
        {
            playMoneySFX();
            DisplayState1.SetActive(false);
            DisplayState2.SetActive(false);
            DisplayState3.SetActive(true);
            DisplayStatelast.SetActive(false);
        }
        else if (m_CurrentMoneySaved > moneyStateLast)
        {
            playMoneySFX();
            DisplayState1.SetActive(false);
            DisplayState2.SetActive(false);
            DisplayState3.SetActive(false);
            DisplayStatelast.SetActive(true);
        }
    }

    /// <summary>
    /// Plays the appropriate sound effect and particle effect based on the current money saved.
    /// </summary>
    void playMoneySFX()
    {
        if(lazyPlayed) return;
        JarParticle.Play();
        lazyPlayed = true;
    }



}
