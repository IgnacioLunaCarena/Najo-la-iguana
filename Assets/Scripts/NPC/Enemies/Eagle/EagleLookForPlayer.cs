using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EagleLookForPlayer : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float searchRadius;
    
    public static Action onTargetFound;
       
    void Update()
    {
        if (LookForPlayer())
        {
            onTargetFound?.Invoke();
            Debug.Log("PlayerFound");
        }
    }
    
    public bool LookForPlayer()
    {
        return Physics.CheckSphere(attackPoint.position, searchRadius, playerLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, searchRadius);
    }
}
