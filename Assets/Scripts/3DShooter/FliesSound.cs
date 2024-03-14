using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using STOP_MODE = FMOD.Studio.STOP_MODE;
using Debug = UnityEngine.Debug;

public class FliesSound : MonoBehaviour
{
    private GameObject flie;
    // Start is called before the first frame update

    private EventInstance flieInstance;
    private void Start()
    {
       // Debug.Log("Flies created");
        flie = this.gameObject;
        //SoundManager.Instance.FliesEnemieEventAttack(flie);
        
        flieInstance = RuntimeManager.CreateInstance(SoundManager.Instance.fliesEnemieEventAttackReference);
        RuntimeManager.AttachInstanceToGameObject(flieInstance, flie.transform);
        flieInstance.start();
    }
    
    void OnDisable()
    {
        flieInstance.stop(STOP_MODE.IMMEDIATE);
        flieInstance.release();
        RuntimeManager.PlayOneShotAttached(SoundManager.Instance.fliesEnemieEventDeathReference, flie);
    }
    

    // Update is called once per frame
    
}
