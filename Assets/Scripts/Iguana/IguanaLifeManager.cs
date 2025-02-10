using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IguanaLifeManager : MonoBehaviour
{
    [SerializeField] private Transform[] tail;
    [SerializeField] private GameObject gameOverMenu;
    private int iguanaLife;    
    private int tailIndex;

    private void Awake()
    {
        IguanaController.onLifeChange += OnLifeChangeHandler;
    }

    private void OnLifeChangeHandler(int life)
    {
        iguanaLife = life;
        //Debug.Log(iguanaLife);
    }
    
    void Update()
    {
        switch (iguanaLife)
        {
            case 7:
                iguanaLife = 6;
                break;
            case 6:
                tailIndex = 0;
                for (int i = tailIndex; i < tail.Length; i++)
                {
                    tail[i].localScale = new Vector3(1, 1, 1);
                }
                break;
            case 5:
                tail[0].localScale = new Vector3(0, 0, 1);
                tailIndex = 1;
                for (int i = tailIndex; i < tail.Length; i++)
                {
                    tail[i].localScale = new Vector3(1, 1, 1);
                }
                break;
            case 4:
                tail[1].localScale = new Vector3(0, 0, 1);
                tailIndex = 2;
                for (int i = tailIndex; i < tail.Length; i++)
                {
                    tail[i].localScale = new Vector3(1, 1, 1);
                }
                break;
            case 3:
                tail[2].localScale = new Vector3(0, 0, 1);
                tailIndex = 3;
                for (int i = tailIndex; i < tail.Length; i++)
                {
                    tail[i].localScale = new Vector3(1, 1, 1);
                }
                break;
            case 2:
                tail[3].localScale = new Vector3(0, 0, 1);
                tailIndex = 4;
                for (int i = tailIndex; i < tail.Length; i++)
                {
                    tail[i].localScale = new Vector3(1, 1, 1);
                }
                break;
            case 1:
                tail[4].localScale = new Vector3(0, 0, 1);
                tailIndex = 5;
                for (int i = tailIndex; i < tail.Length; i++)
                {
                    tail[i].localScale = new Vector3(1, 1, 1);
                }
                break;
            case 0:
                Time.timeScale = 0f;
                Cursor.visible = true;
                gameOverMenu.SetActive(true);
                break;

            default:
                //Debug.Log("VIDA FUERA DEL RANGO");
                break;
        }
    }
   
    private void OnDestroy()
    {
        IguanaController.onLifeChange -= OnLifeChangeHandler;
    }
}
