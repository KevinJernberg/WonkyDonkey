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
            DontDestroyOnLoad(this.gameObject);
        }
    }
    
    [SerializeField] private EventReference FliesMusic;
    private EventInstance fliesMusicInst;
    public UnityAction FliesMusicAction;
    
    [SerializeField] private EventReference PongMusic;
    private EventInstance pongMusicInst;
    public UnityAction PongMusicAction;


    private void OnEnable()
    {
        FliesMusicAction += PlayFliesMusic;
        PongMusicAction += PlayPongMusic;
    }
    
    private void OnDisable()
    {
        FliesMusicAction -= PlayFliesMusic;
        PongMusicAction -= PlayPongMusic;
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

    public void PlayPongMusic()
    {
        pongMusicInst = RuntimeManager.CreateInstance(PongMusic);
        pongMusicInst.start();
    }

    public void StopPongMusic()
    {
        pongMusicInst.release();
        pongMusicInst.stop(STOP_MODE.ALLOWFADEOUT);
    }
}
