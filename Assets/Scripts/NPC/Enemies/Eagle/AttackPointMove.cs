using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPointMove : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minimumDistance;
    private int currentIndex = 0;

    void Update()
    {
        MoveAttackPoint();
    }

    private void MoveAttackPoint()
    {
        Vector3 deltaVector = waypoints[currentIndex].position - transform.position;
        Vector3 direction = deltaVector.normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (deltaVector.magnitude < minimumDistance)
            currentIndex++;

        if (currentIndex >= waypoints.Length)
            currentIndex = 0;
    }
}
