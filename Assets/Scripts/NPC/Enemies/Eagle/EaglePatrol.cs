using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaglePatrol : MonoBehaviour
{
    [SerializeField] private Transform patrolPoint;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
  
    void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        Vector3 deltaVector = new Vector3(patrolPoint.position.x, patrolPoint.position.y + 15f, patrolPoint.position.z) - transform.position;
        Vector3 direction = deltaVector.normalized;
        transform.forward = Vector3.Lerp(transform.forward, direction, rotationSpeed * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
