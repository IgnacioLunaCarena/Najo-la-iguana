using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IguanaLight : MonoBehaviour
{
    [SerializeField] private Light iguanaLight;
    [SerializeField] private float fadeLightSpeed;

    void Start()
    {
        iguanaLight.intensity = 0;
    }

    void Update()
    {
        IguanaLightFade();
    }

    private void IguanaLightFade()
    {
        iguanaLight.intensity -= fadeLightSpeed * Time.deltaTime;
    }

    public void AddLight(float lightAmount)
    {
        iguanaLight.intensity += lightAmount;
    }

    public float GetLight()
    {
        return iguanaLight.intensity;
    }
}
