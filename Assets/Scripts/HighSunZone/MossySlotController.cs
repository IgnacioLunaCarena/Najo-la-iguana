using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MossySlotController : MonoBehaviour
{
    public static Action onMossyActivate;
    public static Action onMossyDeactivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mossy")
        {
            Debug.Log("Entro");
            onMossyActivate?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Mossy")
        {
            Debug.Log("salio");
            onMossyDeactivate?.Invoke();
        }
    }
}
