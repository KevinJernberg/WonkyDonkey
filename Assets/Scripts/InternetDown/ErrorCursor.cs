using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class ErrorCursor : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> sprites;

    [SerializeField] private float cycleTime;
    private float cycleTimer;

    private float spriteTime = 0.15f;
    private float spriteTimer;

    private int spriteCount;

    private void Start()
    {
        cycleTimer = cycleTime;
        spriteTimer = spriteTime;
    }

    private void Update()
    {
        if (cycleTimer > 0)
        {
            cycleTimer -= Time.deltaTime;
            spriteTimer -= Time.deltaTime;

            if (spriteTimer <= 0)
            {
                spriteTimer = spriteTime;
                SwitchSprite();
            }
        }
    }

    private void SwitchSprite()
    {
        spriteCount++;
        if (spriteCount >= sprites.Count)
        {
            spriteCount = 0;
        }
        
        Cursor.SetCursor(sprites[spriteCount].texture, Vector2.zero, CursorMode.ForceSoftware);
    }
}
