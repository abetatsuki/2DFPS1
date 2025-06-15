
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    public int hp = 10;
    public int currentHp ;

    public Transform hpBarForeground; // 緑色バーのTransform
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // 下方向に一定速度で移動させる
        rb.velocity = Vector2.down * speed;
        currentHp = hp;
        UpdateHpBar();


    }

    void Update()
    {
        // 画面外に出たら削除
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
        UpdateHpBar();


    }
    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        currentHp = Mathf.Clamp(currentHp, 0, hp);
        Debug.Log("Enemy HP: " + hp);

        if (currentHp<= 0)
        {
            Destroy(gameObject); // 敵オブジェクトを消す
            Score.score++;
        }
    }
    void UpdateHpBar()
    {
        float hpRatio = (float)currentHp / hp;
        hpBarForeground.localScale = new Vector3(hpRatio, 1f, 1f);
    }
}