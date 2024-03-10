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
    
    [SerializeField] private EventReference VindosMusic;
    private EventInstance vindowsMusicInst;
    public UnityAction VindowsMusicAction;
    
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
        VindowsMusicAction += PlayVindosMusic;
    }
    
    private void OnDisable()
    {
        FliesMusicAction -= PlayFliesMusic;
        PongMusicAction -= PlayPongMusic;
        VindowsMusicAction -= PlayVindosMusic;
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

    public void PlayVindosMusic()
    {
        vindowsMusicInst.getPlaybackState(out PLAYBACK_STATE state);
        if (state != PLAYBACK_STATE.PLAYING)
        {
            vindowsMusicInst = RuntimeManager.CreateInstance(VindosMusic);
            vindowsMusicInst.start();
        }
        
    }
    
    public void StopVindosMusic()
    {
        vindowsMusicInst.release();
        vindowsMusicInst.stop(STOP_MODE.ALLOWFADEOUT);
    }
}
