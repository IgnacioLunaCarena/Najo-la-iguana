using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int scoreInstance;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            scoreInstance = 0;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore()
    {
        instance.scoreInstance += 1;
    }

    public static int GetScore()
    {
        return instance.scoreInstance;
    }

   
}
