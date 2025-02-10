using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarabController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private ScarabData scarabData;
    private ScarabPatrol patrol;
    private ScarabChase chase;
    private ScarabLookAt lookAt;
    private Animator anim;
    private bool canAtack = false;
    private float timeToAtack;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        patrol = GetComponent<ScarabPatrol>();
        chase = GetComponent<ScarabChase>();
        lookAt = GetComponent<ScarabLookAt>();
    }

    void Update()
    {
        timeToAtack += Time.deltaTime;

        PatrolChaseAttackAnim();

        if (DistanceToPlayer() <= scarabData.visionRange)
        {
            if (DistanceToPlayer() >= scarabData.minimumDistanceToPlayer)
                chase.Chase();
            else
            {
                if (canAtack)
                {
                    anim.SetTrigger(scarabData.atackType);
                    timeToAtack = 0f;
                    canAtack = false;
                }
                else
                    lookAt.LookAtPlayer();
                
                if (timeToAtack >= scarabData.hitCooldown)
                    canAtack = true;
            }
        }
        else
        {
            patrol.Patrol();
            patrol.CreateNewWay();
        }
    }
    
    private float DistanceToPlayer()
    {
        return Vector3.Distance(transform.position, player.transform.position);
    }

    private void PatrolChaseAttackAnim()
    {
        anim.SetFloat("DistanceToPlayer", Vector3.Distance(player.position, transform.position));
    }

    private void OnDrawGizmos()
    {
        if (DistanceToPlayer() <= scarabData.visionRange)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, scarabData.visionRange);
    }
}
