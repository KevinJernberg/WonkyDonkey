using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    private void OnEnable()
    {
        PongEntry.beginPong += Launch;
    }
    
    private void OnDisable()
    {
        PongEntry.beginPong -= Launch;
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }
    
    
    
}
