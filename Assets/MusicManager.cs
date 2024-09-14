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
    
    [SerializeField] private EventReference FlyFlapBuzzReference;
    public EventInstance FlyFlapBuzzInst;

    public UnityAction FlyFlapAction;

    [SerializeField] private EventReference FlyFlapDeathReference;
    private EventInstance FlyFlapDeathInst;
    public UnityAction FlyFlapDeathAction;
    
    [SerializeField] private EventReference DoodleJumpRef;
    private EventInstance DoodleJumpInst;
    public UnityAction DoodleJumpMusicAction;
    
    [SerializeField] private EventReference FartSpary;
    private EventInstance FartSparyInst;
    public UnityAction FartSparyAction;

    private void OnEnable()
    {
        FliesMusicAction += PlayFliesMusic;
        PongMusicAction += PlayPongMusic;
        VindowsMusicAction += PlayVindosMusic;
        FlyFlapAction += PlayFlyFlap;
        DoodleJumpMusicAction += PlayDoodleMusic;
    }
    
    private void OnDisable()
    {
        FliesMusicAction -= PlayFliesMusic;
        PongMusicAction -= PlayPongMusic;
        VindowsMusicAction -= PlayVindosMusic;
        FlyFlapAction -= PlayFlyFlap;
        DoodleJumpMusicAction -= PlayDoodleMusic;
    }

    public void PlayFart()
    {
        //FartSparyInst.getPlaybackState(out PLAYBACK_STATE state);
        Debug.Log("Fartspray Is playing");
            FartSparyInst = RuntimeManager.CreateInstance(FartSpary);
            FartSparyInst.start();
    }
    
    public void StopFart()
    {
        Debug.Log("Fart spray Stopped");
        FartSparyInst.release();
        FartSparyInst.stop(STOP_MODE.ALLOWFADEOUT);
    }
    public void PlayFlyFlap()
    {
        FlyFlapMusicInst.getPlaybackState(out PLAYBACK_STATE state);
        if (state != PLAYBACK_STATE.PLAYING)
        {
            FlyFlapMusicInst = RuntimeManager.CreateInstance(FlyFlapMusicReference);

            FlyFlapBuzzInst = RuntimeManager.CreateInstance(FlyFlapBuzzReference);

            FlyFlapMusicInst.start();
            Debug.Log("FlyMusic START");

            FlyFlapBuzzInst.start();
            Debug.Log("FlyBuzz START");
        }
    }

    public void StopFlyFlap()
    {
        FlyFlapMusicInst.stop(STOP_MODE.IMMEDIATE);
        FlyFlapBuzzInst.release();
        Debug.Log("FlyMusic STOP");

        FlyFlapBuzzInst.stop(STOP_MODE.IMMEDIATE);
        FlyFlapMusicInst.release();
        Debug.Log("FlyBuzz STOP");

    }
    public void SetBuzzParameter()
    {
        FlyFlapBuzzInst.setParameterByName("FlappyFlyPitchShifter", 1, false);
    }
    
    
    public void PlayFliesMusic()
    {
        //FLiesMusic is 3D shooter music

        fliesMusicInst = RuntimeManager.CreateInstance(FliesMusic);
        fliesMusicInst.start();
        Debug.Log("Flies Music START 2");
    }
    public void StopFliesMusic()
    {
        fliesMusicInst.release();
        fliesMusicInst.stop(STOP_MODE.ALLOWFADEOUT);
        Debug.Log("Flies Music STOP");
    }
    public void PlayDoodleMusic()
    {
        DoodleJumpInst = RuntimeManager.CreateInstance(DoodleJumpRef);
        DoodleJumpInst.start();
        Debug.Log("Doodle Music START");
    }
    
    public void StopDoodleMusic()
    {
        DoodleJumpInst.release();
        DoodleJumpInst.stop(STOP_MODE.IMMEDIATE);
        Debug.Log("Doodle Music STOP");
    }
   

    public void PlayPongMusic()
    {
        pongMusicInst = RuntimeManager.CreateInstance(PongMusic);
        pongMusicInst.start();
        Debug.Log("Pong Music START");
    }

    public void StopPongMusic()
    {
        pongMusicInst.release();
        pongMusicInst.stop(STOP_MODE.ALLOWFADEOUT);
        Debug.Log("Pong Music STOP");
    }

    public void PlayVindosMusic()
    {
        vindowsMusicInst.getPlaybackState(out PLAYBACK_STATE state);
        if (state != PLAYBACK_STATE.PLAYING)
        {
            vindowsMusicInst = RuntimeManager.CreateInstance(VindosMusic);
            vindowsMusicInst.start();
            Debug.Log("Vindos Music START");
        }
        
    }
    
    public void StopVindosMusic()
    {
        vindowsMusicInst.release();
        vindowsMusicInst.stop(STOP_MODE.ALLOWFADEOUT);
        Debug.Log("Vindos Music STOP");

    }
}
