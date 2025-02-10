using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IguanaSlopeCheck : MonoBehaviour
{
    [SerializeField] private Transform checkPosition;
    [SerializeField] private Transform checkPosition2;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float slopeCheckDistance;

    void Start()
    {
        
    }

    void Update()
    {
        SlopeCheckVertical();
    }

    private void SlopeCheckVertical()
    {
        RaycastHit hit;
        if (Physics.Raycast(checkPosition.position, checkPosition2.position, out hit, groundLayer))
        {
            Debug.DrawLine(hit.point, hit.normal, Color.green);
        }
    }
}
