using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarabAttack : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private ScarabData scarabData;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private AudioClip clip;
    [SerializeField] private ParticleSystem earthquake;
    private ScarabPatrol patrol;
    private ScarabChase chase;
    private ScarabLookAt lookAt;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        patrol = GetComponent<ScarabPatrol>();
        chase = GetComponent<ScarabChase>();
        lookAt = GetComponent<ScarabLookAt>();
    }

    private void StartAttack()
    {
        patrol.enabled = false;
        chase.enabled = false;
        lookAt.enabled = false;
    }

    public void AttackTime()
    {
        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, scarabData.attackRange, playerLayer);
        foreach (Collider player in hitPlayer)
        {
            if (scarabData.atackType == "SoftAttack")
            {
                player.GetComponent<IguanaController>().GetDamage(1);
            }
            else
            {
                player.GetComponent<IguanaController>().GetDamage(2);
                audioSource.PlayOneShot(clip);
                earthquake.Play();
            }
        }
    }

    private void FinishAttack()
    {
        patrol.enabled = true;
        chase.enabled = true;
        lookAt.enabled = true;
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, scarabData.attackRange);
    }
}
