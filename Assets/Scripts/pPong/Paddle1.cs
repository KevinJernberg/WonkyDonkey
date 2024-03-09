using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle1 : MonoBehaviour
{
    public bool isPlayer;

    public float speed;

    public Rigidbody2D rb;

    private float movement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float pos = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;


        pos = Mathf.Clamp(pos, -3.7f, 3.7f);

        transform.position = new Vector3(transform.position.x, pos, transform.position.z);
    }
}
