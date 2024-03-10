using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Events;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; } 
    
    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }
    
    [SerializeField] private EventReference FliesMusic;
    private EventInstance fliesMusicInst;
    public UnityAction FliesMusicAction;
    
    private void OnEnable()
    {
        FliesMusicAction += PlayFliesMusic;
    }
    
    private void OnDisable()
    {
        FliesMusicAction -= PlayFliesMusic;
    }

    public void PlayFliesMusic()
    {
        fliesMusicInst = RuntimeManager.CreateInstance(FliesMusic);
        fliesMusicInst.start();
    }
    
    public void StopFliesMusic()
    {
        fliesMusicInst.release();
        fliesMusicInst.stop(STOP_MODE.ALLOWFADEOUT);
    }
}
