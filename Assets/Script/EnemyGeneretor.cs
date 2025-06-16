using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneretor : MonoBehaviour
{
    public GameObject enemyPrefab;         // 敵のプレハブ
    public float spawnInterval = 2f;       // 出現間隔（秒）
    public float xRange = 8f;              // 出現範囲（X座標の幅）
    public Transform EnemyScale;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        float x = Random.Range(-xRange, xRange);
        Vector3 spawnPosition = new Vector3(x, transform.position.y, 0);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}