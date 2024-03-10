using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class FlyManager : MonoBehaviour
{
    private float timer;

    public static UnityAction flyEnd;
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 20)
        {
            DinoManager.stopgame?.Invoke();
        }
    }
}
