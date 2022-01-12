using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public EnemyLogic[] enemies;
        public int count;
        public float timeBtwSpawns;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBtwWaves;

    private Wave currentWave;
    private int currentWaveIndex;
    private Transform player;

    public bool fininshedSpawning;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
    }
    void Update()
    {
        if (fininshedSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            fininshedSpawning = false;
            if (currentWaveIndex + 1 < waves.Length)
            {
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
            else
            {
                Debug.Log("Game Finished");
            }
        }
    }

    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(timeBtwWaves);
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index)
    {
        currentWave = waves[index];
        for (int i = 0; i < currentWave.count; i++)
        {
            if (player == null)
            {
                yield break;
            }

            EnemyLogic randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);

            if (i == currentWave.count - 1)
            {
                fininshedSpawning = true;
            }
            else
            {
                fininshedSpawning = false;
            }

            yield return new WaitForSeconds(currentWave.timeBtwSpawns);
        }
    }
}
