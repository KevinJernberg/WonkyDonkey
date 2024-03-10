using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BlueScreenVolume : MonoBehaviour
{

    private bool active;
    
    private Volume _volume;


    private void Start()
    {
        _volume = GetComponent<Volume>();
    }

    private void OnEnable()
    {
        DinoManager.stopgame += Toggle;
    }
    
    private void OnDisable()
    {
        DinoManager.stopgame -= Toggle;
    }

    private void Toggle()
    {
        active = true;
    }

    private void Update()
    {
        if (active)
        {
            if (_volume.weight < 1)
            {
                _volume.weight += Time.deltaTime * 5;
            }
        }
    }
}
