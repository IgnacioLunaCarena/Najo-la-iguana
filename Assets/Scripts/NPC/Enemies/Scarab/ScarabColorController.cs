using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarabColorController : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer scarab;
    [SerializeField] private ScarabData scarabData;

    void Start()
    {
        scarab = GetComponent<SkinnedMeshRenderer>();
    }

    void Update()
    {
        scarab.material = scarabData.scarabColor;
    }
}
