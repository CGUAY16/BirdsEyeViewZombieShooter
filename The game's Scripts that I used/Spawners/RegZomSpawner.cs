using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegZomSpawner : MonoBehaviour
{
    [SerializeField] RegZombie regZomPrefab;
    [SerializeField] float spawnCooldown;
    float nextSpawnTime;

    // Update is called once per frame
    void Update()
    {
        if (spawnerReady())
        {
            StartCoroutine(SpawnRegZom());
        }
    }

    IEnumerator SpawnRegZom()
    {
        nextSpawnTime = Time.time + spawnCooldown;
        RegZombie regZombie = Instantiate(regZomPrefab, transform.position, transform.rotation);
        yield return null;
    }

    bool spawnerReady() => Time.time >= nextSpawnTime;
}
