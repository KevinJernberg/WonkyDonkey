using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paddle1 : MonoBehaviour
{
    public bool isPlayer;

    public float speed;

    public Rigidbody2D rb;

    private float movement;
    
    private float timer;
    private bool ending;

    // Update is called once per frame

    private void OnEnable()
    {
        PongManager.endPong += CheckForMe;
    }
    
    private void OnDisable()
    {
        PongManager.endPong -= CheckForMe;
    }

    private void CheckForMe(GameObject paddle)
    {
        if (paddle == this.gameObject)
        {
            GetComponent<Animator>().enabled = true;
            ending = true;
        }
    }
    

    void Update()
    {
        float pos = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;


        pos = Mathf.Clamp(pos, -3.7f, 3.7f);

        transform.position = new Vector3(transform.position.x, pos, transform.position.z);


        if (ending)
        {
            if (timer < 4)
            {
                timer += Time.deltaTime;
                
                if (timer >= 4)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ball"))
        {
            PongManager.instance.AddCount();
        }
    }
}
