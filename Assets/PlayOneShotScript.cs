using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
public class PlayOneShotScript : MonoBehaviour
{

    public EventReference OneShotOnAwake;
    // Start is called before the first frame update
    void Awake()
    {
        RuntimeManager.PlayOneShot(OneShotOnAwake);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
