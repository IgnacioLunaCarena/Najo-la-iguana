using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EagleAttack : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform player;
    [SerializeField] private ParticleSystem impact;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackRadius;
    [SerializeField] private float minimumDistance;
    [SerializeField] private float animSpeed;
    private Animator anim;
    private bool canAttack = false;

    public static Action onPlayerAttacked;
    public static Action onPlayerMissed;

    void Start()
    {
        anim = GetComponent<Animator>();
        animSpeed = 1f;
    }

    void Update()
    {
        if (canAttack)
            Attack();
    }

    private void Attack()
    {
        transform.position += Direction().normalized * attackSpeed * Time.deltaTime;
        transform.LookAt(attackPoint);
        anim.speed = animSpeed;
        if (Direction().magnitude <= minimumDistance)
        {
            Debug.Log("Entro");
            impact.Play();
            if (Physics.CheckSphere(attackPoint.position, attackRadius, playerLayer))
            {
                animSpeed = 1f;
                anim.SetTrigger("Attack");
                onPlayerAttacked?.Invoke();
                canAttack = false;
            }
            else
            {
                animSpeed = 1f;
                onPlayerMissed?.Invoke();
                canAttack = false;
            }
        }
    }

    private Vector3 Direction()
    {
        return attackPoint.position - transform.position;
    }

    public void CanAttack()
    {
        attackPoint.position = player.position;
        canAttack = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
