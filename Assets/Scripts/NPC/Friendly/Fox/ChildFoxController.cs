using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildFoxController : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minimumDistance;
    private int currentIndex = 0;

    void Update()
    {
        MoveAround();
    }

    private void MoveAround()
    {
        Vector3 deltaVector = waypoints[currentIndex].position - transform.position;
        Vector3 direction = deltaVector.normalized;
        transform.forward = Vector3.Lerp(transform.forward, direction, rotationSpeed * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;

        if (deltaVector.magnitude < minimumDistance)
            currentIndex++;
        if (currentIndex >= waypoints.Length)
            currentIndex = 0;
    }
}
