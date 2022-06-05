using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public Transform[] points;
    public float HP;
    public float timeToSpawn, timeBetweenWaves;
    public int numOfEnemiesPerWave;
    
    private int _currentNumOfEnemies;
    private float _enemyTimer, _waveTimer;

    void Start()
    {
        _currentNumOfEnemies = 0;
        _enemyTimer = timeToSpawn;
        _waveTimer = 0; 
    }

    void Update()
    {
        _waveTimer -= Time.deltaTime;

        if (_waveTimer <= 0)
        {
            if (_currentNumOfEnemies < numOfEnemiesPerWave)
            {
                _enemyTimer -= Time.deltaTime;

                if (_enemyTimer <= 0)
                {
                    
                    Enemy enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                    enemy.points = points;
                    enemy.HP = HP;
                    _currentNumOfEnemies++;

                    _enemyTimer = timeToSpawn;
                }
            }
            else
            {
                HP += 20;
                _currentNumOfEnemies = 0;
                _waveTimer = timeBetweenWaves + 1;
                numOfEnemiesPerWave += 2;
            }
        }
    }
}

