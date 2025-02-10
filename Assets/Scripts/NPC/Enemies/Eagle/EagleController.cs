using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour
{
    [SerializeField] private float timeToLookForPlayer;
    [SerializeField] private ParticleSystem attackSign;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AttackPointMove attackPointMove;
    private EaglePatrol patrol;
    private EagleLookForPlayer lookForPlayer;
    private EagleAttackPointOrbit attackPointOrbit;
    private EagleAttack attack;
    private AudioSource audioSource;

    private void Awake()
    {
        EagleLookForPlayer.onTargetFound += OnTargetFoundHandler;
        EagleAttack.onPlayerAttacked += OnPlayerAttacked;
        EagleAttack.onPlayerMissed += OnPlayerMissed;
    }

    private void Start()
    {
        patrol = GetComponent<EaglePatrol>();
        lookForPlayer = GetComponent<EagleLookForPlayer>();
        attackPointOrbit = GetComponent<EagleAttackPointOrbit>();
        attack = GetComponent<EagleAttack>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTargetFoundHandler()
    {
        audioSource.PlayOneShot(clip);
        attackSign.Play();
        attack.enabled = true;
        attack.CanAttack();
        attackPointMove.enabled = false;
        patrol.enabled = false;
        lookForPlayer.enabled = false;
        attackPointOrbit.enabled = false;
    }

    private void OnPlayerAttacked()
    {
        attackSign.Stop();
        attack.enabled = false;
        attackPointMove.enabled = true;
        patrol.enabled = true;
        attackPointOrbit.enabled = true;
        StartCoroutine(TimeToLookForPlayer());
    }

    private void OnPlayerMissed()
    {
        attackSign.Stop();
        attack.enabled = false;
        attackPointMove.enabled = true;
        patrol.enabled = true;
        attackPointOrbit.enabled = true;
        StartCoroutine(TimeToLookForPlayer());
    }

    IEnumerator TimeToLookForPlayer()
    {
        yield return new WaitForSeconds(timeToLookForPlayer);
        lookForPlayer.enabled = true;
    }

    private void OnDestroy()
    {
        EagleLookForPlayer.onTargetFound -= OnTargetFoundHandler;
        EagleAttack.onPlayerAttacked -= OnPlayerAttacked;
        EagleAttack.onPlayerMissed -= OnPlayerMissed;
    }
}
