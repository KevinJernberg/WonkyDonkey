using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBugSight : MonoBehaviour
{
    public bool seesPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            seesPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            seesPlayer = false;
        }
    }
}
