using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ScarabData", menuName = "Scarab Data")]

public class ScarabData : ScriptableObject
{
    public int life;
    public float patrolSpeed;
    public float chaseSpeed;
    public float visionRange;
    public float minimumDistanceToPlayer;
    public float hitCooldown;
    public float attackRange;
    public float xArea;
    public float zArea;
    public float turnSmoothTime = 0.1f;
    public string atackType;
    public Material scarabColor;
}
