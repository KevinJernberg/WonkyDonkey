using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out EnemyBugMovement bug))
        {
            bug.isHit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out EnemyBugMovement bug))
        {
            bug.isHit = false;
        }
    }
}
