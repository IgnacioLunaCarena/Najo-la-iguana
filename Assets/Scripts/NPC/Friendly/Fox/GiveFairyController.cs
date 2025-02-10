using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveFairyController : MonoBehaviour
{
    [SerializeField] private GameObject fairy;
    private bool questComplete = false;

    void Start()
    {
        fairy.SetActive(false);
    }

    void Update()
    {
        if (questComplete)
            GiveFairy();
    }

    private void GiveFairy()
    {
        fairy.SetActive(true);
    }

    public void QuestCompleted()
    {
        questComplete = true;
    }
}
