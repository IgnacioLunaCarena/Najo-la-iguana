using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleAttackPointOrbit : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minimumDistance;
    private int currentIndex = 0;

    private void Awake()
    {
        EagleLookForPlayer.onTargetFound += OnTargetFoundHandler;
    }

    void Update()
    {
        AttackPointMove();
    }

    private void AttackPointMove()
    {
        Vector3 deltaVector = waypoints[currentIndex].position - attackPoint.position;
        Vector3 direction = deltaVector.normalized;
        attackPoint.forward = Vector3.Lerp(attackPoint.forward, direction, rotationSpeed * Time.deltaTime);
        attackPoint.position += attackPoint.forward * speed * Time.deltaTime;

        if (deltaVector.magnitude < minimumDistance)
            currentIndex++;

        if (currentIndex >= waypoints.Length)
            currentIndex = 0;
    }

    private void OnTargetFoundHandler()
    {
        this.enabled = false;
    }

    private void OnDestroy()
    {
        EagleLookForPlayer.onTargetFound -= OnTargetFoundHandler;
    }
}
