using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class InternetUp : MonoBehaviour
{
    private bool wait;
    private float timer;

    [SerializeField]
    private Volume glitch;

    [SerializeField]
    private GameObject internetrestored;
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
        wait = true;
    }

    private void Update()
    {
        if (wait)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                internetrestored.SetActive(true);
            }
            if (timer > 4)
            {
                glitch.weight = Mathf.Min(1f, glitch.weight + Time.deltaTime * 0.5f);
            }
            if (timer > 4)
            {
                FlyBehaviour.stop = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
