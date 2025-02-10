using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AridSlotController : MonoBehaviour
{
    public static Action onAridActivate;
    public static Action onAridDeactivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Arid")
        {
            Debug.Log("Entro");
            onAridActivate?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Arid")
        {
            Debug.Log("salio");
            onAridDeactivate?.Invoke();
        }
    }
}
