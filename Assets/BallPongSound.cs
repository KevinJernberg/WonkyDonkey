using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPongSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Pong Sound");
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Pong Sound Player");
            SoundManager.Instance.PongBallAction?.Invoke();
        }
       
    }
}
