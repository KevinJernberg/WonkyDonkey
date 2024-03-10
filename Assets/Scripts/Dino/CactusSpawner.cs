using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CactusSpawner : MonoBehaviour
{
    private float timer;

    public bool right;
    
    [SerializeField]
    private GameObject cactusPrefab;
    
    [SerializeField]
    private Vector3 cactusSpawnPoint;

    [SerializeField, Range(0, 20)]
    private float cactusSpawnTime;
    
    [SerializeField, Range(0, 20)]
    private float cactusSpawnTimeDeviation;

    private float timeDevation;
    
    private bool stop;

    private void Start()
    {
        timeDevation = Random.Range(-cactusSpawnTimeDeviation, cactusSpawnTimeDeviation);
        timer = cactusSpawnTime + timeDevation;
    }
    
    private void OnEnable()
    {
        DinoManager.stopgame += Stop;
    }
    
    private void OnDisable()
    {
        DinoManager.stopgame -= Stop;
    }

    void Update()
    {
        if (stop) return;
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
        GameObject cactus = Instantiate(cactusPrefab, transform.position, Quaternion.Euler(0, 0, right ? 90 : -90));
        Destroy(cactus, 100f);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(cactusSpawnPoint ,1);
    }
    
    private void Stop()
    {
        stop = true;
    }
}