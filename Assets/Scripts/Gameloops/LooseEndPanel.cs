using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseEndPanel : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public PanelSpriteBehavior[] spritesToSwap;
    private bool runPingPong = false;
    public bool RunPingPong { get { return runPingPong; } set { runPingPong = value; } }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(delayToSwap());
        spriteRenderer.sprite = spritesToSwap[0].Sprite;
    }
    int i = 0;
    IEnumerator delayToSwap()
    {
        while(i < spritesToSwap.Length)
        {

            yield return new WaitForSeconds(spritesToSwap[i].DelayinSeconds);
            runPingPong = true;
            i++;
        }
    }
    float FPongUP = 0.0f;
    float FPongDown = 1f;
    void Update()
    {
        if (runPingPong)
        {
            spriteRenderer.color = new Color(1, 1, 1, FPongDown);
            FPongDown -= 0.1f * Time.deltaTime;
            if (FPongDown <= 0)
            {
                spriteRenderer.sprite = spritesToSwap[i].Sprite;
                spriteRenderer.color = new Color(1, 1, 1, FPongUP);
                FPongUP += 0.1f * Time.deltaTime;
                if (FPongUP >= 1)
                {
                    runPingPong = false;
                }

            }
        }
    }
}
[System.Serializable]
public class PanelSpriteBehavior
{
    public float DelayinSeconds = 5f;
    public Sprite Sprite;
}
