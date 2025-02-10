using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IguanaFootstep : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    private AudioSource audioSource;
    private IguanaJump iguanaJump;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        iguanaJump = GetComponent<IguanaJump>();
    }

    private void Step()
    {
        if (iguanaJump.IsGrounded())
        {
            AudioClip clip = GetRandomClip();
            audioSource.PlayOneShot(clip);
        }
    }

    private AudioClip GetRandomClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }
}
