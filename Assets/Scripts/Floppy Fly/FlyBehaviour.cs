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
    public static bool stop;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.zero;
        stop = false;

        MusicManager.Instance.FlyFlapAction?.Invoke();
    }


    // Update is called once per frame
    void Update()
    {
        if (stop) return;
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
            if (MusicManager.Instance != null)
                MusicManager.Instance.SetBuzzParameter();
            _rb.velocity = Vector2.up * _velocity;
        } 
    }

    private void FixedUpdate()
    {
        if (stop) return;
        transform.rotation = Quaternion.Euler(0,0, _rb.velocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            Stop();
            FlyManager.flyEnd?.Invoke();
            MusicManager.Instance.StopFlyFlap();
            SoundManager.Instance.FlySplatAction?.Invoke();
        }
    }
    
    private void OnEnable()
    {
        DinoManager.stopgame += Stop;
    }
    
    private void OnDisable()
    {
        DinoManager.stopgame -= Stop;
    }
    
    private void Stop()
    {
        _rb.bodyType = RigidbodyType2D.Static;
        stop = true;
        GetComponent<Animator>().enabled = false;
    }
}
