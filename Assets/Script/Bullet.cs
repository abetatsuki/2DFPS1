
using UnityEngine;


public class Bullet : MonoBehaviour
{
  
    
  
    public float speed = 10f; // 弾のスピード
   
    private Rigidbody2D rb;
    public int damage = 1;
    public AudioClip explosionSound;     // 爆発音
    public GameObject explosionEffect;   // 爆発エフェクトのPrefab
    public float explosionEffectDuration = 1.5f; // エフェクトの消去タイミング


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y > 10f)
        {
            Destroy(gameObject);
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
       
       
        if (other.CompareTag("Enemy"))  // "Enemy" タグのときだけ敵を消す
        {
            //GetComponent<Enemy>() で「そのGameObjectにくっついてるEnemyスクリプト」を取得これで相手のスクリプトにアクセスできる
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // ダメージを与える
            }
            if (explosionEffect != null)//prefabになにかアタッチされてるなら
            {　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　//	回転させずに（デフォルトの向きで）出す
                GameObject effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(effect, explosionEffectDuration); // "explosionEffectDuration"秒後に消す
            }

            // --- 爆発音を再生 ---
            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }




            // 敵を消す
            Destroy(this.gameObject);    // 弾を消す
           

        }
    }
}
