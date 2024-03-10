using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMOD.Studio;

public class FliesSound : MonoBehaviour
{
    private GameObject flie;
    // Start is called before the first frame update
    
    void Start()
    {
        flie = this.gameObject;
        SoundManager.Instance.FliesEnemieEventAttack(flie);
    }

    // Update is called once per frame
    
}
