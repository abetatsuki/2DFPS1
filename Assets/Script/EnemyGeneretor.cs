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
    public GameObject BossPrefab;
    private GameObject bossInstance;
    public bool isBossSpawned = false;

    private int nextScoreThreshold = 10;   // ★ 次のスコア目標
    private float minSpawnInterval = 0.1f; // ★ 最短間隔

    void Start()
    {
        Time.timeScale = 1f;
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            CancelInvoke("SpawnEnemy");
            return;
        }

        // スコア10ごとに間隔を短縮（ボスモード中はしない）
        if (!isBossMode && Score.score >= nextScoreThreshold)
        {
            AdjustSpawnInterval();
            nextScoreThreshold += 10;
        }

        // 敵生成が止まっている場合に再開
        if (!IsInvoking("SpawnEnemy"))
        {
            if (isBossMode)
            {
                InvokeRepeating("SpawnEnemy", 0f, bossSpawnInterval);
            }
            else
            {
                InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
            }
        }

        // ボス出現判定
        if (Score.score >= 100 && !isBossSpawned)
        {
            SpawnBoss();
            isBossSpawned = true;
        }

        // ボス生成後の状態切り替え
        if (bossInstance != null && !isBossMode)
        {
            isBossMode = true;
            CancelInvoke("SpawnEnemy");
            InvokeRepeating("SpawnEnemy", 0f, bossSpawnInterval);
        }
        else if (bossInstance == null && isBossMode)
        {
            isBossMode = false;
            CancelInvoke("SpawnEnemy");
            InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
        }
    }

    void AdjustSpawnInterval() // ★ 追加メソッド
    {
        spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - 0.1f); // 最短0.5秒まで
        CancelInvoke("SpawnEnemy");
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
        Debug.Log("出現間隔変更: " + spawnInterval + " 秒 (スコア:" + Score.score + ")");
    }

    void SpawnEnemy()
    {
        int randomScale = Random.Range(1, 4);
        float x = Random.Range(-xRange, xRange);
        Vector3 spawnPosition = new Vector3(x, transform.position.y, 0);
        EnemyScale.localScale = new Vector3(randomScale, randomScale, 1f);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    public void SpawnBoss()
    {
        bossInstance = Instantiate(BossPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log("ボス登場！");
    }
}
