using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class CactusSpawner : MonoBehaviour
{
    private float timer;
    
    [SerializeField]
    private GameObject cactusPrefab;
    
    [SerializeField]
    private Vector3 cactusSpawnPoint;

    [SerializeField, Range(0, 20)]
    private float cactusSpawnTime;
    
    [SerializeField, Range(0, 20)]
    private float cactusSpawnTimeDeviation;

    private float timeDevation;

    private void Start()
    {
        timeDevation = Random.Range(-cactusSpawnTimeDeviation, cactusSpawnTimeDeviation);
        timer = cactusSpawnTime + timeDevation;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = cactusSpawnTime + timeDevation;
            timeDevation = Random.Range(-cactusSpawnTimeDeviation, cactusSpawnTimeDeviation);
            SpawnCactus();
        }
    }

    private void SpawnCactus()
    {
        GameObject cactus = Instantiate(cactusPrefab, cactusSpawnPoint, Quaternion.identity);
        Destroy(cactus, 100f);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(cactusSpawnPoint ,1);
    }
}