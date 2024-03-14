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
        SoundManager.Instance.SolvedRiddleActionShort?.Invoke();
        Debug.Log("Instance played");
        animator.SetTrigger("Open");
    }
}
