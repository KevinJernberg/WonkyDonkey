using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class FlyManager : MonoBehaviour
{
    private void Awake()
    {
        MusicManager.Instance.StopVindosMusic();
        MusicManager.Instance.PlayFlyFlap();
    }

    private float timer;

    public static UnityAction flyEnd;
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 15)
        {
            DinoManager.stopgame?.Invoke();
        }
    }
}
