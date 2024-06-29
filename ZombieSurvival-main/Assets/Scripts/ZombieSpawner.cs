using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private Transform zombieSpawnPoints;
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private float randomSpawnTime = 10f;
    [SerializeField] private int zombieSpawned = 0;

    private Transform[] spawnPoints;
    private bool spawnloop = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        spawnPoints = zombieSpawnPoints.GetComponentsInChildren<Transform>();
        while (spawnloop)
        {
            yield return new WaitForSeconds(Random.Range(3, randomSpawnTime));
            SpawnZombie();
        }
    }

    private void SpawnZombie()
    {
        int i = Random.Range(1, spawnPoints.Length);
        GameObject newZombie = Instantiate(zombiePrefab, spawnPoints[i].transform.position, transform.rotation);
        newZombie.transform.parent = transform;
        zombieSpawned++;
    }
}
