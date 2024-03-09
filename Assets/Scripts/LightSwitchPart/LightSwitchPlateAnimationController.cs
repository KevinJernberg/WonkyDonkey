using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchPlateAnimationController : MonoBehaviour
{
    private Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Open()
    {
        animator.SetTrigger("Open");
    }
}
