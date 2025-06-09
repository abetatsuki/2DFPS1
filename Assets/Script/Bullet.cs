
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public int score1;
    
  
    public float speed = 10f; // ’e‚ÌƒXƒs[ƒh
   
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
       
       
        if (other.CompareTag("Enemy"))  // "Enemy" ƒ^ƒO‚Ì‚Æ‚«‚¾‚¯“G‚ğÁ‚·
        {
            Debug.Log("Hit enemy: " + other.name);
            Score.score++;

            Destroy(other.gameObject);   // “G‚ğÁ‚·
            Destroy(this.gameObject);    // ’e‚ğÁ‚·
           

        }
    }
}
