using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneController : MonoBehaviour
{
    [SerializeField] private IguanaController iguana;
    [SerializeField] private IguanaColorController iguanaColor;
    [SerializeField] private SkinnedMeshRenderer iguanaSMR;

    private void Awake()
    {
        IguanaController.onSafeZoneEnter += OnSafeZoneEnterHandler;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            iguana.HighSunZone();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            iguana.HighSunZone();
    }
    
    private void OnSafeZoneEnterHandler()
    {
        iguanaColor.HeatDown(iguanaSMR.material.color);
    }

    private void OnDestroy()
    {
        IguanaController.onSafeZoneEnter -= OnSafeZoneEnterHandler;
    }
}
