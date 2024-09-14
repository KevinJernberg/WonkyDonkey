using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class FlyManager : MonoBehaviour
{

    private float timer;
    public bool not;

    public static UnityAction flyEnd;
    
    
    private void Awake()
    {
       if (MusicManager.Instance != null)
       {
            MusicManager.Instance.StopVindosMusic();

        }
    }
    private void Update()
    {
        if (not) return;
        timer += Time.deltaTime;

        if (timer > 15)
        {
            DinoManager.stopgame?.Invoke();
        }
    }
}
