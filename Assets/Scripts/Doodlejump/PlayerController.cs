using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;

    private float moveX;

    private float lastX = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // moveX = Input.GetAxis("Horizontal") * moveSpeed;
       float pos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
       transform.position = new Vector3(pos, transform.position.y, transform.position.z);
       if (transform.position.y >= 115f)
       {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
           MusicManager.Instance.StopDoodleMusic();
       }
    }

    private void FixedUpdate()
    {
        if (transform.position.x > lastX)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        
        lastX = transform.position.x; 
        Vector2 velocity = rb.velocity;
        velocity.x = moveX;
        rb.velocity = velocity;
    }
}
