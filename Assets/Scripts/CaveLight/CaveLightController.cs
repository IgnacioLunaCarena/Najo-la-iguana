using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CaveLightController : MonoBehaviour
{
    [SerializeField] private Color lightColor;
    [SerializeField] private Color darkColor;
    [SerializeField] private float swapLightLerpTime;
    private bool swapDark;
   
    private void Update()
    {
        if (swapDark)
            RenderSettings.ambientLight = Color.Lerp(RenderSettings.ambientLight, darkColor, swapLightLerpTime * Time.deltaTime);
        else
            RenderSettings.ambientLight = Color.Lerp(RenderSettings.ambientLight, lightColor, swapLightLerpTime * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            swapDark = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            swapDark = false;
    }
}
