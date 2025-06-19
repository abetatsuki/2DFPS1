using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneretor : MonoBehaviour
{
    public GameObject enemyPrefab;         // 敵のプレハブ
    public float spawnInterval = 2f;       // 通常の出現間隔
    public float bossSpawnInterval = 1f;   // ボス登場時の出現間隔
    public float xRange = 8f;              // 出現範囲（X座標の幅）
    public Transform EnemyScale;
    private bool isBossMode = false;


    private GameObject boss;               // ボスを保持

    void Start()
    {
        // ボスを探す（"Boss"という名前でヒエラルキーにある場合）
        boss = GameObject.Find("Boss");
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void Update()
    {
        boss = GameObject.Find("Boss");

        if (boss != null && !isBossMode)
        {
            isBossMode = true;
            CancelInvoke("SpawnEnemy");
            InvokeRepeating("SpawnEnemy", 0f, bossSpawnInterval);
        }
        else if (boss == null && isBossMode)
        {
            isBossMode = false;
            CancelInvoke("SpawnEnemy");
            InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
        }
    }


    void SpawnEnemy()
    {
        int randomScale = Random.Range(1, 4);
        float x = Random.Range(-xRange, xRange);
        Vector3 spawnPosition = new Vector3(x, transform.position.y, 0);
        EnemyScale.localScale = new Vector3(randomScale, randomScale, 1f);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

}
