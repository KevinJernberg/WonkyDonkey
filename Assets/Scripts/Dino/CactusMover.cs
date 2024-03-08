using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusMover : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float cactusSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.left * cactusSpeed * Time.deltaTime; 
    }
}
