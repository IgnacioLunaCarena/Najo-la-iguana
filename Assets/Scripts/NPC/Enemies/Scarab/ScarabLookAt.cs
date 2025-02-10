using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarabLookAt : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private ScarabData scarabData;
    private float turnSmoothVelocity;

    public void LookAtPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, scarabData.turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}
