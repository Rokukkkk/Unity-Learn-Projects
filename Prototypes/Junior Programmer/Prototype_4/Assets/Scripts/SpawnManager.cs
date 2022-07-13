using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public float range = 8;
    public int enemyCount;
    public int waveNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWaves(waveNum);
        Instantiate(powerupPrefab, GenerateSpawnLocation(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNum++;
            SpawnEnemyWaves(waveNum);
            Instantiate(powerupPrefab, GenerateSpawnLocation(), powerupPrefab.transform.rotation);
        }
    }

    void SpawnEnemyWaves(int enemyToSpawn)
    {
        for (int i = 0; i < enemyToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnLocation(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnLocation()
    {
        float rangeX = Random.Range(-range, range);
        float rangeZ = Random.Range(-range, range);

        return new Vector3(rangeX, 0, rangeZ);
    }
}
