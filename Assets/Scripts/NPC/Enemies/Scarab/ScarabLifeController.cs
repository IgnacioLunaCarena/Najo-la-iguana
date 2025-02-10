using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScarabLifeController : MonoBehaviour
{
    [SerializeField] private ScarabData scarabData;
    [SerializeField] private Material color1;
    [SerializeField] private Material color2;
    [SerializeField] private Material color3;
    private Animator anim;

    public static Action onDead;

    private void Start()
    {
        anim = GetComponent<Animator>();
        scarabData.life = 3;
    }

    private void Update()
    {
        switch (scarabData.life)
        {
            case 3:
                scarabData.patrolSpeed = 3;
                scarabData.chaseSpeed = 5;
                scarabData.hitCooldown = 2f;
                scarabData.attackRange = 1f;
                scarabData.atackType = "SoftAttack";
                scarabData.scarabColor = color1;
                break;
           
            case 2:
                scarabData.patrolSpeed = 5;
                scarabData.chaseSpeed = 7;
                scarabData.hitCooldown = 1f;
                scarabData.attackRange = 1f;
                scarabData.atackType = "SoftAttack";
                scarabData.scarabColor = color2;
                break;
            
            case 1:
                scarabData.patrolSpeed = 5;
                scarabData.chaseSpeed = 8;
                scarabData.hitCooldown = 2f;
                scarabData.attackRange = 2f;
                scarabData.atackType = "HeavyAttack";
                scarabData.scarabColor = color3;
                break;

            case 0:
                Debug.Log("Scarab Die");
                onDead?.Invoke();
                anim.SetBool("isDead", true);
                GetComponent<CapsuleCollider>().enabled = false;
                GetComponent<ScarabController>().enabled = false;
                GetComponent<ScarabPatrol>().enabled = false;
                GetComponent<ScarabChase>().enabled = false;
                GetComponent<ScarabAttack>().enabled = false;
                this.enabled = false;
                break;

            default:
                Debug.Log("Out of range");
                break;
        }
    }

    public void GetDamage()
    {
        scarabData.life--;
        anim.SetTrigger("TakeDamage");
    }
}
