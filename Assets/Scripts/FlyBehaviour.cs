using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyBehaviour : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;

    private Rigidbody2D _rb;

    [SerializeField, Range(0, 3)] private float switchTime;
    private float switchTimer;
    
    private bool immunityFrames;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (switchTimer > 0)
        {
            switchTimer -= Time.deltaTime;
            immunityFrames = true;
            if (switchTimer <= 0)
            {
                immunityFrames = false;
            }
        }
        
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            _rb.velocity = Vector2.up * _velocity;
        } 
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0,0, _rb.velocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (immunityFrames) return;
            if (other.gameObject.CompareTag("Pipe"))
        {
            GetComponent<SpriteRenderer>().flipY = !GetComponent<SpriteRenderer>().flipY;
            _velocity = -_velocity;
            _rb.gravityScale = -_rb.gravityScale;
            switchTimer = switchTime;
        }
    }
}
