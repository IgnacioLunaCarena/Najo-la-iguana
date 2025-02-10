using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDialogController : MonoBehaviour
{
    [SerializeField] private GiveQuest startQuestDialog;
    [SerializeField] private QuestComplete questCompleteDialog;
    private bool questComplete = false;

    private void Awake()
    {
        QuestProgress.onQuestCompleted += OnQuestCompletedHandler;
    }

    private void Update()
    {
        if (questComplete)
        {
            startQuestDialog.enabled = false;
            questCompleteDialog.enabled = true;
        }
        else
        {
            startQuestDialog.enabled = true;
            questCompleteDialog.enabled = false;
        }
    }

    private void OnQuestCompletedHandler()
    {
        questComplete = true;
    }

    private void OnDestroy()
    {
        QuestProgress.onQuestCompleted -= OnQuestCompletedHandler;
    }
}
