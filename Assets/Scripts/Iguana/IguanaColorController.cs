using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IguanaColorController : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer iguanaSMR;
    [SerializeField] private float heatUpLerpTime;
    [SerializeField] private float heatDownLerpTime;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color burnColor;
    private float hurtCooldown = 2f;
    private float timeToHurt = 0f;
    private bool canHurt = true;

    public static Action onSunHurt;

    private void Update()
    {
        //Debug.Log(iguanaSMR.material.color);

        if (iguanaSMR.material.color.r <= 0.63f && canHurt)            
             SunHurt();
        else
            timeToHurt += Time.deltaTime;

        if (timeToHurt >= hurtCooldown)
            canHurt = true;
    }
    
    public void HeatUp(Color color)
    {
        //Debug.Log("HeatingUp");
        iguanaSMR.material.color = Color.Lerp(color, burnColor, heatUpLerpTime * Time.deltaTime);
    }

    public void HeatDown(Color color)
    {
        //Debug.Log("HeatingDown");
        iguanaSMR.material.color = Color.Lerp(color, normalColor, heatDownLerpTime * Time.deltaTime);
    }

    private void SunHurt()
    {
        onSunHurt?.Invoke();
        timeToHurt = 0;
        canHurt = false;
    }
}
