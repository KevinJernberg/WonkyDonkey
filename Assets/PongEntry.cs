using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class PongEntry : MonoBehaviour
{
    public Volume pp;

    private float timer;

    public static UnityAction beginPong;

    private void Update()
    {
        if (timer < 1)
        {
            timer += Time.deltaTime;

            pp.weight = 1 - timer;
            if (timer >= 1)
            {
                beginPong?.Invoke();
            }
        }
    }
}
