using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Glitchdinoend : MonoBehaviour
{
    private bool wait;
    private float timer;

    private void OnEnable()
    {
        DinoManager.stopgame += Toggle;
    }

    private void OnDisable()
    {
        DinoManager.stopgame -= Toggle;
    }

    private void Toggle()
    {
        wait = true;
    }

    private void Update()
    {
        if (wait)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                Destroy(this.gameObject);
            }
        }
    }
}
