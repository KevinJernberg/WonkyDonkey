using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitManager : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(WaitToQuit());
    }

    private IEnumerator WaitToQuit()
    {
        yield return new WaitForSeconds(20f);
        
        Application.Quit();
    }
}