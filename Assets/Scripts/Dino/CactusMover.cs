using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusMover : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float cactusSpeed;

    private bool stop;

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
        transform.localPosition += Vector3.up * cactusSpeed * Time.deltaTime; 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Damn");
        if (other.transform.CompareTag("CactusDespawner"))
        {
            Destroy(this.gameObject);
        }
    }

    private void Stop()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        stop = true;
    }
}
