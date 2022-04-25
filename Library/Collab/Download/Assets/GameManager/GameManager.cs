using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityNightPool;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    private bool singletonCreated;

    private void Awake()
    {
        singletonCreated = CreateSingleton();
        if(singletonCreated)
        {
            
        }


    }

    private bool CreateSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return true;
        }
        else
        {
            Destroy(gameObject);
            return false;
        }
        
    }


}
