using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IguanaAttack : MonoBehaviour
{
    [SerializeField] private IguanaData iguanaData;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemies;
    [SerializeField] private ParticleSystem rightHandSlash;
    [SerializeField] private ParticleSystem leftHandSlash;
    private Animator animPlayer;
    private IguanaMove iguanaMove;
    private float attackRate = 2f;
    private float nextAttackTime = 0f;

    void Start()
    {
        animPlayer = GetComponent<Animator>();
        iguanaMove = GetComponent<IguanaMove>();
    }
       
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                if (iguanaMove.GetDirecion().magnitude >= 0.1f)
                    rightHandSlash.Play();
                else
                    leftHandSlash.Play();

                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    private void Attack()
    {
        animPlayer.SetTrigger("Attack");
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, iguanaData.attackRange, enemies);
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Hit" + enemy.name);
            enemy.GetComponent<ScarabLifeController>().GetDamage();
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;
       
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(attackPoint.position, iguanaData.attackRange);
    }
}
