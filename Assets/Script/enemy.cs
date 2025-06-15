
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    public int hp = 3;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // 下方向に一定速度で移動させる
        rb.velocity = Vector2.down * speed;

       
    }

    void Update()
    {
        // 画面外に出たら削除
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log("Enemy HP: " + hp);

        if (hp <= 0)
        {
            Destroy(gameObject); // 敵オブジェクトを消す
        }
    }
}