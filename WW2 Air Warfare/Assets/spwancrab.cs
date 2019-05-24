using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwancrab : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public float spawnTime = 2f;

    public GameObject enemy;
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);

    }
    private void Update()
    {

    }
    void SpawnEnemy()
    {
        int spwanIndex = Random.Range(0, SpawnPoints.Length);
        Instantiate(enemy, SpawnPoints[spwanIndex].position, SpawnPoints[spwanIndex].rotation);

    }
}
