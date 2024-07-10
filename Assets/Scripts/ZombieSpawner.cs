using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform player;
    public float spawnTime = 5f;
    public float spawnRadius = 10f;

    void Start()
    {
        InvokeRepeating("SpawnZombie", spawnTime, spawnTime);
    }

    void SpawnZombie()
    {
        Vector3 spawnPosition = player.position + (Random.insideUnitSphere * spawnRadius);
        spawnPosition.y = 0;
        Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
    }
}
