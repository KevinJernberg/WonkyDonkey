using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroText : MonoBehaviour
{
    private RectTransform transformRec;

    private float timer;
    private void Start()
    {
        transformRec = GetComponent<RectTransform>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 18)
        {
            SceneManager.LoadScene("FlappyBird");
        }
        transformRec.position += Vector3.up * 100 * Time.deltaTime;
    }
}
