using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{

    private int clickAmount;
    [SerializeField] private GameObject circuitPart;
    private void OnMouseDown()
    {
        transform.localScale += new Vector3(0, -(transform.localScale.y * 2), 0);
        clickAmount++;

        if (clickAmount >= 10)
        {
            EnableCircuitPart();
            Destroy(transform.parent.gameObject);
        }
    }


    private void EnableCircuitPart()
    {
        circuitPart.SetActive(true);
    }
}
