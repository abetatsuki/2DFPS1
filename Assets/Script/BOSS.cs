using UnityEngine;

public class Boss : MonoBehaviour
{
    public float moveSpeed = 2f;    // 左右移動スピード
    private float moveDirection = 1f; // 1: 右へ, -1: 左へ

    void Update()
    {
        Move();
    }

    void Move()
    {
        // 左右移動
        transform.Translate(Vector2.right * moveSpeed * moveDirection * Time.deltaTime);

        // 画面端で方向転換
        if (transform.position.x > 7f || transform.position.x < -7f)
        {
            moveDirection *= -1f;
        }
    }
}
