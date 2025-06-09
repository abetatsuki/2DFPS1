using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // 下方向に一定速度で移動させる
        rb.velocity = Vector2.down * speed;
    }

    void Update()
    {
        // 画面外に出たら削除（任意）
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}