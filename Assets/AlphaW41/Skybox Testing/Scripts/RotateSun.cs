using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.StickyNote;

public class RotateSun : MonoBehaviour
{
    public GameObject Sun;
    public Skybox skybox;

    public Color StarColor;
    public Color Afternoon;
    public Color MidDaySkyColor;
    public Color NightColor;

    private void Update()

    {
        float sunRotation = transform.rotation.eulerAngles.x; 
        transform.Rotate(10 * Time.deltaTime,0,0);
        Sun.transform.Rotate(0, 0, 25 * Time.deltaTime);
        Debug.Log(sunRotation);
        Debug.Log((sunRotation - 30) / (60-30));

        if (sunRotation < 360 && sunRotation > 330)
        {
            Debug.Log("Phase1");
            RenderSettings.skybox.SetColor("_Tint", Color.Lerp(StarColor, NightColor, (-sunRotation + 360 )/ 30));
        }
       


        if (sunRotation > 0 && sunRotation < 30)
        {
            Debug.Log("Phase1");
            RenderSettings.skybox.SetColor("_Tint", Color.Lerp(StarColor, Afternoon, sunRotation/30));
        }
        else if (sunRotation > 30 && sunRotation < 60)
        {
            Debug.Log("Phase2");
            RenderSettings.skybox.SetColor("_Tint", Color.Lerp(Afternoon, MidDaySkyColor, (sunRotation - 30) / (60-30)));
        }
        else if (sunRotation > 60 && sunRotation < 120)
        {
            Debug.Log("Phase3");
            RenderSettings.skybox.SetColor("_Tint", Color.Lerp(MidDaySkyColor, MidDaySkyColor, (sunRotation -60) / 120));
        }
        else if (sunRotation > 120 && sunRotation < 150)
        {
            Debug.Log("Phase4");
            RenderSettings.skybox.SetColor("_Tint", Color.Lerp(MidDaySkyColor, Afternoon, sunRotation / 150));
        }

        else if (sunRotation > 150 && sunRotation < 180)
        {
            Debug.Log("Phase5");
            RenderSettings.skybox.SetColor("_Tint", Color.Lerp(Afternoon, StarColor, (sunRotation - 150) / 180));
        }
        

    }
}
