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
        // 1～3の整数の中からランダムに選ぶ
        int randomScale = Random.Range(1, 4); // 4は含まれないので1,2,3のどれかになる
        float x = Random.Range(-xRange, xRange);
        Vector3 spawnPosition = new Vector3(x, transform.position.y, 0);
        EnemyScale.localScale = new Vector3(1f, 1f, 1f);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}