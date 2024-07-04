using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform[] spawnPoints;
    public float spawnTime = 3f;

    void Start()
    {
        InvokeRepeating("SpawnZombie", spawnTime, spawnTime);
    }

    void SpawnZombie()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(zombiePrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
