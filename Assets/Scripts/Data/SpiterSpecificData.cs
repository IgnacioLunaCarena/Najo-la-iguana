using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpiterSpecificData", menuName = "Spiter Specific Data")]

public class SpiterSpecificData : ScriptableObject
{
    public float lerpSpeed;
    public float shootForce;
    public int shootCooldown;
    public int changeCooldown;
    public float shootFix;
}  
