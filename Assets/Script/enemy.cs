
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float Speed = 3f;
    private Rigidbody2D rb;
    public int Hp ;
    public int CurrentHp ;

    public Transform HPBarForeground; // 緑色バーのTransform
    private Vector3 originalForegroundScale;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // 下方向に一定速度で移動させる
        rb.velocity = Vector2.down * Speed;
        CurrentHp = Hp;
        originalForegroundScale = HPBarForeground.localScale;
        UpdateHpBar();
       
        Debug.Log(originalForegroundScale);


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
        CurrentHp -= damage;
        CurrentHp = Mathf.Clamp(CurrentHp, 0, Hp);
        Debug.Log("Enemy HP: " + Hp);

        if (CurrentHp<= 0)
        {
            Destroy(gameObject); // 敵オブジェクトを消す
            Score.score++;
        }
    }
    void UpdateHpBar()
    {
        float hpRatio = (float)CurrentHp / Hp;
        HPBarForeground.localScale = new Vector3(originalForegroundScale.x*hpRatio, originalForegroundScale.y, originalForegroundScale.z);
    }
}