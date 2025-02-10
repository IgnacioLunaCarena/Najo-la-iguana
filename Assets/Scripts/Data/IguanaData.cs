using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New IguanaData", menuName = "Iguana Data")]
public class IguanaData : ScriptableObject
{
    public int life;
    public float speed;
    public float jumpForce;
    public float attackRange;
    public float rayCastDistance;
}
