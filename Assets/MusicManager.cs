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
    
    [Header("FlappyFly")]

    [SerializeField] private EventReference FlyFlapMusicReference;
    private EventInstance FlyFlapMusicInst;
    public UnityAction FlyFlapMusicAction;
    
    [SerializeField] private EventReference FlyFlapBuzzReference;
    public EventInstance FlyFlapBuzzInst;
    public UnityAction FlyFlapBuzzAction;
    
    [SerializeField] private EventReference FlyFlapDeathReference;
    private EventInstance FlyFlapDeathInst;
    public UnityAction FlyFlapDeathAction;
    
    [SerializeField] private EventReference DoodleJumpRef;
    private EventInstance DoodleJumpInst;
    public UnityAction DoodleJumpAction;
    
    [SerializeField] private EventReference FartSpary;
    private EventInstance FartSparyInst;
    public UnityAction FartSparyAction;

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

    public void PlayFart()
    {
        //FartSparyInst.getPlaybackState(out PLAYBACK_STATE state);
        Debug.Log("Is playing");
            FartSparyInst = RuntimeManager.CreateInstance(FartSpary);
            FartSparyInst.start();
            
    }
    
    public void StopFart()
    {
        Debug.Log("is Stopped");
        FartSparyInst.release();
        FartSparyInst.stop(STOP_MODE.ALLOWFADEOUT);
    }
    public void PlayFlyFlap()
    {
        FlyFlapMusicInst = RuntimeManager.CreateInstance(FlyFlapMusicReference);
        FlyFlapBuzzInst = RuntimeManager.CreateInstance(FlyFlapBuzzReference);
        FlyFlapMusicInst.start();
        FlyFlapBuzzInst.start();
    }

    public void SetBuzzParameter()
    {
        FlyFlapBuzzInst.setParameterByName("FlappyFlyPitchShifter", 1, false);
    }

    public void StopFlyFlap()
    {
        FlyFlapMusicInst.release();
        FlyFlapMusicInst.stop(STOP_MODE.IMMEDIATE);
        FlyFlapBuzzInst.release();
        FlyFlapBuzzInst.stop(STOP_MODE.IMMEDIATE);
        RuntimeManager.PlayOneShot(FlyFlapDeathReference);
    }
    
    public void PlayFliesMusic()
    {
        fliesMusicInst = RuntimeManager.CreateInstance(FliesMusic);
        fliesMusicInst.start();
    }

    public void PlayDoodleMusic()
    {
        DoodleJumpInst = RuntimeManager.CreateInstance(DoodleJumpRef);
        DoodleJumpInst.start();
    }
    
    public void StopDoodleMusic()
    {
        DoodleJumpInst.release();
        DoodleJumpInst.stop(STOP_MODE.IMMEDIATE);
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
