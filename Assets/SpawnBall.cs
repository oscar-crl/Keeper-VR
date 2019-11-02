using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour {
    private float nextSpawnTime;
    public GameObject ballPrefab;
    public float spawnDelay;

    private void Update()
    {
        if (SpawnTime())
            Spawn();
    }

    private void Spawn()
    {
        nextSpawnTime = Time.time + spawnDelay;
        ballPrefab.GetComponent<Rigidbody>().useGravity = false;
        Instantiate(ballPrefab, transform.position, transform.rotation);
    }

    private bool SpawnTime()
    {
        return Time.time >= nextSpawnTime;
    }
}
