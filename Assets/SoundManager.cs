using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using UnityEditorInternal;
using UnityEngine.Events;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
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

    //[Header("CoockieLevel")]
    public List<EventReference> CoockieLevel = new List<EventReference>();
    
    //[Header("DinoJump")]
    public List<EventReference> DinoJump = new List<EventReference>();
    
    //[Header("Flappyfly")]
    public List<EventReference> Flappyfly = new List<EventReference>();
    
    //[Header("KlickSound")]
    public List<EventReference> KlickSound = new List<EventReference>();
    
    //[Header("Pong")]
    public List<EventReference> Pong = new List<EventReference>();
    
    //[Header("VoiceLines")]
    public List<EventReference> VoiceLines = new List<EventReference>();

    public EventInstance instFliest;
    
    [Header("Paper")]
    [SerializeField] private EventReference paperPickUpReference;
    public UnityAction PaperPickUpAction;
    
    [SerializeField] private EventReference paperPutDownReference;
    public UnityAction paperPutDownAction;

    [Header("Klick")] 
    [SerializeField] private EventReference klickReference;
    public UnityAction KlickEventAction;

    [Header("3D Shooters")]
    [SerializeField] private EventReference fliesEnemieEventAttackReference;
    public UnityAction fliesEnemiesEventAttackAction;
    
    [SerializeField] private EventReference fliesEnemieEventDeathReference;
    public UnityAction fliesEnemieEventDeathAtcion;
    
    [Header("pong")]
    [SerializeField] private EventReference PongBallReference;
    public UnityAction PongBallAction;
    
    [SerializeField] private EventReference PongSwooshReference;
    public UnityAction PongSwooshAction;
    
    
    private void OnEnable()
    {
        PaperPickUpAction += PaperPickUp;
        paperPutDownAction += PaperPutDownAction;
        //fliesEnemiesEventAttackAction += FliesEnemieEventAttack;
       // fliesEnemieEventDeathAtcion += FliesEnemiesDeath;
       PongBallAction += PlayBallHit;
       PongSwooshAction += PlayPongSwoosh;
       KlickEventAction += PlayKlick;

    }
    private void OnDisable()
    {
        PaperPickUpAction -= PaperPickUp;
        paperPutDownAction -= PaperPutDownAction;
        //fliesEnemiesEventAttackAction -= FliesEnemiesDeath;
        //fliesEnemieEventDeathAtcion -= FliesEnemiesDeath;
        PongBallAction -= PlayBallHit;
        PongSwooshAction -= PlayPongSwoosh;
        KlickEventAction -= PlayKlick;
    }

    public void PlayKlick()
    {
        RuntimeManager.PlayOneShot(klickReference);
        Debug.Log("Klick");
    }
    private void PaperPickUp()
    {
        RuntimeManager.PlayOneShot(paperPickUpReference);
    }

    private void PaperPutDownAction()
    {
        RuntimeManager.PlayOneShot(paperPutDownReference);
    }

    public void FliesEnemieEventAttack(GameObject FlieObject)
    {
        RuntimeManager.PlayOneShotAttached(fliesEnemieEventAttackReference, FlieObject);
    }

    private void FliesEnemiesDeath()
    {
        
    }

    public void PlayBallHit()
    {
        RuntimeManager.PlayOneShot(PongBallReference);
    }

    public void PlayPongSwoosh()
    {
        RuntimeManager.PlayOneShot(PongSwooshReference);
    }

    
    
}
