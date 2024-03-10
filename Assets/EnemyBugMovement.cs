using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBugMovement : MonoBehaviour
{
    public EnemyBugSight sight;
    public Animator anim;
    public Rigidbody rb;

    public float enemySpeed;

    private void Update()
    {
        if (sight.seesPlayer)
        {
            anim.enabled = true;
            rb.velocity =
                Vector3.ProjectOnPlane(
                    ThirdDPlayerController.Instance.transform.position - transform.position, Vector3.up).normalized * enemySpeed;
        }
        else
        {
            anim.enabled = false;
        }
    }
}
