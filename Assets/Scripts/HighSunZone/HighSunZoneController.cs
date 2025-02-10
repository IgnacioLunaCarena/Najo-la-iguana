using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighSunZoneController : MonoBehaviour
{
    [SerializeField] private IguanaController iguana;
    [SerializeField] private IguanaColorController iguanaColor;
    [SerializeField] private SkinnedMeshRenderer iguanaSMR;

    private void Awake()
    {
        IguanaController.onHighSunZoneEnter += OnHighSunZoneEnterHandler;
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

    private void OnHighSunZoneEnterHandler()
    {
        iguanaColor.HeatUp(iguanaSMR.material.color);
    }

    private void OnDestroy()
    {
        IguanaController.onHighSunZoneEnter -= OnHighSunZoneEnterHandler;
    }
}
