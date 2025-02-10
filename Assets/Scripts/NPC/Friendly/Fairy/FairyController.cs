using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyController : MonoBehaviour
{
    [SerializeField] private IguanaLight iguanaLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (iguanaLight.GetLight() <= 2)
            {
                iguanaLight.AddLight(5);
                this.gameObject.SetActive(false);
            }
            else
            {
                iguanaLight.AddLight(7 - iguanaLight.GetLight());
                this.gameObject.SetActive(false);
            }
        }
    }
}
