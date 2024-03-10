using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float _speed = 0.65f;


    private bool stop;
    
    private void OnEnable()
    {
        FlyManager.flyEnd += Stop;
        DinoManager.stopgame += Stop;
    }
    
    private void OnDisable()
    {
        FlyManager.flyEnd -= Stop;
        DinoManager.stopgame -= Stop;
    }
    
    private void Stop()
    {
        stop = true;
        Animator[] animators = GetComponentsInChildren<Animator>();
        foreach (Animator animator in animators)
        {
            animator.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stop) return;
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
