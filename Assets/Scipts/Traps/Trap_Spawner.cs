using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Spawner : MonoBehaviour
{
    public GameObject trapPrefab;
    public float spawnIntervalMin = 5f;
    public float spawnIntervalMax = 10f;
    public Vector2 spawnAreaSize = new Vector2(10f, 5f);

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    void Update()
    {

        if (Time.time >= nextSpawnTime)
        {
            SpawnTrap();
            nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
        }
    }

    void SpawnTrap()
    {
        Vector2 spawnPosition = transform.position + new Vector3(Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f), Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f));

        GameObject spawnedTrap = Instantiate(trapPrefab, spawnPosition, Quaternion.identity);

        OutOfCameraDestroyer destroyer = spawnedTrap.AddComponent<OutOfCameraDestroyer>();
        destroyer.destroyDistance = 20f;
    }
}