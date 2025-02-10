using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarabPatrol : MonoBehaviour
{
    [SerializeField] private Transform reference;
    [SerializeField] private Transform waypoint;
    [SerializeField] private ScarabData scarabData;
    private float turnSmoothVelocity;

    public void Patrol()
    {
        Vector3 direction = (waypoint.position - transform.position).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, scarabData.turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        transform.position += moveDir * scarabData.patrolSpeed * Time.deltaTime;
    }

    public void CreateNewWay()
    {
        if (Vector3.Distance(transform.position, waypoint.transform.position) <= 0.2f)
        {
            float xIndex = UnityEngine.Random.Range((reference.transform.position.x - (scarabData.xArea / 2)), (reference.transform.position.x + (scarabData.xArea / 2)));
            float zIndex = UnityEngine.Random.Range((reference.transform.position.z - (scarabData.zArea / 2)), (reference.transform.position.z + (scarabData.zArea / 2)));
            waypoint.transform.position = new Vector3(xIndex, waypoint.transform.position.y, zIndex);
        }
    }
}
