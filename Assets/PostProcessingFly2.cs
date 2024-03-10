using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PostProcessingFly2 : MonoBehaviour
{
    private float _timer;
    
    private bool stop;

    [SerializeField] private Volume pp1;
    [SerializeField] private Volume pp2;
    
    private void OnEnable()
    {
        FlyManager.flyEnd += Stop;
    }
    
    private void OnDisable()
    {
        FlyManager.flyEnd -= Stop;
    }
    
    private void Stop()
    {
        stop = true;
    }

    private void Update()
    {
        if (stop)
        {
            pp1.gameObject.SetActive(false);
            pp2.gameObject.SetActive(true);

            _timer += Time.deltaTime;

            if (_timer > 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
