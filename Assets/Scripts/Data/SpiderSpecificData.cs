using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpiderSpecificData", menuName = "Spider Specific Data")]

public class SpiderSpecificData : ScriptableObject
{
    public float chaseSpeed;
    public float distanceToPlayer;
    public float hitCooldown;
    public int changeCooldown;
}
