using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZomSpawner : MonoBehaviour
{   
    [SerializeField] SlowZombie slowZomPrefab;
    [SerializeField] float spawnCooldown;
    float nextSpawnTime;

    // Update is called once per frame
    void Update()
    {
        if (spawnerReady())
        {
            StartCoroutine(SpawnSlowZom());
        }
    }

    IEnumerator SpawnSlowZom()
    {
        nextSpawnTime = Time.time + spawnCooldown;
        SlowZombie slowZombie = Instantiate(slowZomPrefab, transform.position, transform.rotation);
        yield return null;
    }

    bool spawnerReady() => Time.time >= nextSpawnTime;
}
