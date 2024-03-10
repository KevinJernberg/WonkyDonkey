using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchFly2 : MonoBehaviour
{
    [SerializeField]
    private GameObject gamobj1;
    [SerializeField]
    private GameObject gamobj2;
    private void OnEnable()
    {
        FlyManager.flyEnd += Stop;
    }
    
    private void OnDisable()
    {
        FlyManager.flyEnd -= Stop;
    }
    
    private void Stop()
    {
        gamobj1.SetActive(true);
    }
}