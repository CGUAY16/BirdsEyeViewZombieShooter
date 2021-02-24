using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastZomSpawner : MonoBehaviour
{
    [SerializeField] FastZombie fastZomPrefab;
    [SerializeField] float spawnCooldown;
    float nextSpawnTime;

    // Update is called once per frame
    void Update()
    {
        if (spawnerReady())
        {
            StartCoroutine(SpawnFastZom());
        }
    }

    IEnumerator SpawnFastZom()
    {
        nextSpawnTime = Time.time + spawnCooldown;
        FastZombie fastZombie = Instantiate(fastZomPrefab, transform.position, transform.rotation);
        yield return null;
    }

    bool spawnerReady() => Time.time >= nextSpawnTime;
}
