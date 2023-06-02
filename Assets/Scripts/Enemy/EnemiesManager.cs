using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Vector2 spawnArea;
    [SerializeField] private float spawnTimer;
    [SerializeField] private GameObject player;
    private float timer;

    private void Update()
    {
        if (MagicSurvivor.magicSurvivorS.GetGameState == GameState.FINISHED) return;

        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().SetTarget(player);
    }
    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();
        
        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f) 
        { 
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }

        if (position.x > 16f)
            position.x = 16f;
        else if (position.x < -16f)
            position.x = -16f;

        if (position.y > 16f)
            position.y = 16f;
        else if (position.y < -16f)
            position.y = -16f;

        return position;
    }
}
