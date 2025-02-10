using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestProgress : MonoBehaviour
{
    private int scarabKilled;

    public static Action onQuestCompleted;

    private void Awake()
    {
        ScarabLifeController.onDead += OnDeadHandler;
    }
    
    void Update()
    {
        if (scarabKilled >= 4)
        {
            Debug.Log("Quest Complete");
            onQuestCompleted?.Invoke();
        }
            
    }

    private void OnDeadHandler()
    {
        scarabKilled++;
        Debug.Log("scarabas killed" + scarabKilled);
    }

    private void OnDestroy()
    {
        ScarabLifeController.onDead -= OnDeadHandler;
    }
}
