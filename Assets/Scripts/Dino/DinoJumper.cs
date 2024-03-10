using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class DinoJumper : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private SpriteRenderer spriteRenderer;

    private bool gravToLeft;
    
    private bool grounded;

    private float hitTimer;
    
    private bool stop;

    [SerializeField, Range(1, 20)] private float jumpForce;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Physics2D.gravity = new Vector2(-1, 0);
    }
    
    private void OnEnable()
    {
        DinoManager.stopgame += Stop;
    }
    
    private void OnDisable()
    {
        DinoManager.stopgame -= Stop;
    }

    // Update is called once per frame
    void Update()
    {
        if (stop) return;
        if (hitTimer > 0)
        {
            spriteRenderer.color = Color.red;
            hitTimer -= Time.deltaTime;
            if (hitTimer > 1)
            {
                rb.velocity = Vector2.zero;
            }
            if (hitTimer <= 0)
            {
                spriteRenderer.color = Color.white;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.DinoJumpAction?.Invoke();
            gravToLeft = !gravToLeft;
            Physics2D.gravity = new Vector2(gravToLeft ? 3 : -3, 0);
            spriteRenderer.flipY = !spriteRenderer.flipY;
            rb.velocity = Vector2.zero;
        }
    }
 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Cactus") && hitTimer <= 0)
        {
            transform.position = new Vector3(0.5f, 1.1f, 0);
            rb.velocity = Vector2.zero;
            hitTimer = 2;
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            SoundManager.Instance.DinoCoinAction?.Invoke();
            DinoManager.Instance.AddCoin(other.gameObject);
        }
    }

    private void Stop()
    {
        GetComponent<Animator>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        stop = true;
    }
}
