using System;
using System.Collections;
using System.Collections.Generic;
using FMOD;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.Events;
using Debug = UnityEngine.Debug;
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
    // public List<EventReference> DinoJump = new List<EventReference>();
    
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
    [SerializeField] public EventReference fliesEnemieEventAttackReference;

    private EventInstance flieAttackInst;
    public UnityAction fliesEnemiesEventAttackAction;
    
    [SerializeField] public EventReference fliesEnemieEventDeathReference;
    public UnityAction fliesEnemieEventDeathAtcion;
    
    [Header("pong")]
    [SerializeField] private EventReference PongBallReference;
    public UnityAction PongBallAction;
    
    [SerializeField] private EventReference PongSwooshReference;
    public UnityAction PongSwooshAction;
    
    [Header("Wire")]
    [SerializeField] private EventReference PhatError;
    public UnityAction PhatErrorAction;
    
    [SerializeField] private EventReference SolvedRiddle;
    public UnityAction SolvedRiddleAction;
    [SerializeField] private EventReference SolvedRiddleShort;
    public UnityAction SolvedRiddleActionShort;
    
    [SerializeField] private EventReference lightFlick;
    public UnityAction LightFlickAction;
    
    [SerializeField] private EventReference PaperBin;
    public UnityAction PaperBinAction;
    
    [SerializeField] private EventReference dinoJump;
    public UnityAction DinoJumpAction;
    
    [SerializeField] private EventReference dinoCoin;
    public UnityAction DinoCoinAction;


    //[Header("FlappyFly")]
    //[SerializeField] private EventReference FlyFlapReference;
   // public UnityAction FlyFlapAction;
    
    private void OnEnable()
    {
        PaperPickUpAction += PaperPickUp;
        paperPutDownAction += PaperPutDownAction; 
        //fliesEnemiesEventAttackAction += FliesEnemieEventAttack;
       //fliesEnemieEventDeathAtcion += FliesEnemiesDeath;
       PongBallAction += PlayBallHit;
       PongSwooshAction += PlayPongSwoosh;
       KlickEventAction += PlayKlick;
       LightFlickAction += PlayLightFlick;
       SolvedRiddleActionShort += PlayRiddleSolvedShort;
       PaperBinAction += playPaper;
       DinoJumpAction += DinoJump;
       DinoCoinAction += DinoCoin;


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
        LightFlickAction -= PlayLightFlick;
        SolvedRiddleActionShort -= PlayRiddleSolvedShort;
        PaperBinAction -= playPaper;
        DinoJumpAction -= DinoJump;
        DinoCoinAction -= DinoCoin;

    }

    
    
    private void PlayPhatError()
    {
        RuntimeManager.PlayOneShot(PhatError);
    }
    public void PlayKlick()
    {
        RuntimeManager.PlayOneShot(klickReference);
        Debug.Log("Klick");
    }

    public void PlayRiddleSolved()
    {
        RuntimeManager.PlayOneShot(SolvedRiddle);
    }

    public void playPaper()
    {
        RuntimeManager.PlayOneShot(PaperBin);
    }

    public void DinoJump()
    {
        RuntimeManager.PlayOneShot(dinoJump);
    }

    public void DinoCoin()
    {
        RuntimeManager.PlayOneShot(dinoCoin);
    }

    private void PlayRiddleSolvedShort()
    {
        RuntimeManager.PlayOneShot(SolvedRiddleShort);
    }

    private void PlayLightFlick()
    {
        RuntimeManager.PlayOneShot(lightFlick);
    }
    
    private void PaperPickUp()
    {
        RuntimeManager.PlayOneShot(paperPickUpReference);
    }

    private void PaperPutDownAction()
    {
        RuntimeManager.PlayOneShot(paperPutDownReference);
    }

    public void FliesEnemieEventAttack(GameObject flieObject)
    {
        flieAttackInst = RuntimeManager.CreateInstance(fliesEnemieEventAttackReference);
        RuntimeManager.AttachInstanceToGameObject(flieAttackInst, flieObject.transform);
        flieAttackInst.start();
    }

    public void FliesEnemiesDeath(GameObject flieObject)
    {
        flieAttackInst.stop(STOP_MODE.IMMEDIATE);
        flieAttackInst.release();
        RuntimeManager.PlayOneShotAttached(fliesEnemieEventDeathReference, flieObject);
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
