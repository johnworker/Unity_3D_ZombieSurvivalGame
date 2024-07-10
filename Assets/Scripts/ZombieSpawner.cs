using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform[] spawnPoints;
    public float spawnTime = 5f;

    void Start()
    {
        InvokeRepeating("SpawnZombie", spawnTime, spawnTime);
    }

    void SpawnZombie()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];
        Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
