
using UnityEngine;


public class enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // ‰º•ûŒü‚Éˆê’è‘¬“x‚ÅˆÚ“®‚³‚¹‚é
        rb.velocity = Vector2.down * speed;

       
    }

    void Update()
    {
        // ‰æ–ÊŠO‚Éo‚½‚çíœ
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}