using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestComplete : MonoBehaviour
{
    [SerializeField] private GameObject fairy;
    [SerializeField] private GameObject questPanel;
    [SerializeField] private GameObject[] questDialogs;
    private int dialogNumber = 0;
    private bool playerInRange = false;

    void Start()
    {
        questPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
            dialogNumber++;

        if (Input.GetKeyDown(KeyCode.Q) && dialogNumber > 0 && playerInRange)
            dialogNumber--;

        Debug.Log(dialogNumber);

        switch (dialogNumber)
        {
            case 0:
                questPanel.SetActive(false);
                questDialogs[0].SetActive(false);
                questDialogs[1].SetActive(false);
                questDialogs[2].SetActive(false);
                break;

            case 1:
                questPanel.SetActive(true);
                questDialogs[0].SetActive(true);
                questDialogs[1].SetActive(false);
                questDialogs[2].SetActive(false);
                break;

            case 2:
                questDialogs[0].SetActive(false);
                questDialogs[1].SetActive(true);
                questDialogs[2].SetActive(false);
                break;

            case 3:
                questDialogs[0].SetActive(false);
                questDialogs[1].SetActive(false);
                questDialogs[2].SetActive(true);
                fairy.SetActive(true);
                break;

            case 4:
                dialogNumber = 0;
                break;

            default:
                Debug.Log("Out of range");
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
    }
}
