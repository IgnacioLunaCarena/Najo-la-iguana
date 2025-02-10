using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private GameObject winMenu;

    private void OnTriggerEnter(Collider other)
    {
        Cursor.visible = true;
        winMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
