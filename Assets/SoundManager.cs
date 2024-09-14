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


    [Header("FlapyFly")]
    [SerializeField] private EventReference FlySplatReference;
    public UnityAction FlySplatAction;

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

    [Header("Doodle Jump")]
    [SerializeField] private EventReference DoodleJumpsReference;
    public UnityAction DoodleJumpAction;

    //[Header("FlappyFly")]
    //[SerializeField] private EventReference FlyFlapReference;
    // public UnityAction FlyFlapAction;

    private void OnEnable()
    {
        FlySplatAction += FlySplat;
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
       DoodleJumpAction += PlayDoodleJumpSound;


    }
    private void OnDisable()
    {
        FlySplatAction -= FlySplat;
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

    
    public void FlySplat()
    {
        RuntimeManager.PlayOneShot(FlySplatReference);
        Debug.Log("Fly Splat");
    }
    private void PlayPhatError()
    {
        RuntimeManager.PlayOneShot(PhatError);
        Debug.Log("PhateError OneShot Played");
    }
    public void PlayKlick()
    {
        RuntimeManager.PlayOneShot(klickReference);
        Debug.Log("Klick OneShot Played");
    }

    public void PlayRiddleSolved()
    {
        RuntimeManager.PlayOneShot(SolvedRiddle);
        Debug.Log("SolvedRiddle OneShot Played");
    }

    public void playPaper()
    {
        RuntimeManager.PlayOneShot(PaperBin);
        Debug.Log("PaperBin OneShot Played");
    }

    public void DinoJump()
    {
        RuntimeManager.PlayOneShot(dinoJump);
        Debug.Log("DinoJump OneShot Played");
    }

    public void DinoCoin()
    {
        RuntimeManager.PlayOneShot(dinoCoin);
        Debug.Log("DinoCoin OneShot Played");
    }

    private void PlayRiddleSolvedShort()
    {
        RuntimeManager.PlayOneShot(SolvedRiddleShort);
        Debug.Log("SolvedRiddleShrt OneShot Played");
    }

    private void PlayLightFlick()
    {
        RuntimeManager.PlayOneShot(lightFlick);
        Debug.Log("LightFlck OneShot Played");
    }
    
    private void PaperPickUp()
    {
        RuntimeManager.PlayOneShot(paperPickUpReference);
        Debug.Log("PaperPickUp OneShot Played");
    }

    private void PaperPutDownAction()
    {
        RuntimeManager.PlayOneShot(paperPutDownReference);
        Debug.Log("PaperPutdwn OneShot Played");
    }

    public void PlayBallHit()
    {
        RuntimeManager.PlayOneShot(PongBallReference);
        Debug.Log("BallHiit OneShot Played");
    }

    public void PlayPongSwoosh()
    {
        RuntimeManager.PlayOneShot(PongSwooshReference);
        Debug.Log("PongSwhoos");
    }

    public void PlayDoodleJumpSound()
    {

        RuntimeManager.PlayOneShot(DoodleJumpsReference);
        Debug.Log("DoodleJump");
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

}
