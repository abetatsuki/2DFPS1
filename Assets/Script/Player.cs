
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class Player : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public bool stopbullet =false;
    public int i;
    public ScoreBord scoreBoard;
    public GameObject sss;
    public bool MenuUI = false;

    void Update()
    {
        // 横移動
        float moveX = Input.GetAxisRaw("Horizontal");
        Vector3 newPosition = transform.position + new Vector3(moveX, 0, 0) * moveSpeed * Time.deltaTime;

        // X座標を -10 から 10 の範囲に制限
        newPosition.x = Mathf.Clamp(newPosition.x, -8f, 8f);//Mathf.Clamp(value, min, max) は、value を min 以上 max 以下の範囲に収める関数です。


        transform.position = newPosition;



        // 弾を発射（スペースキー）
        if (Input.GetKey(KeyCode.Space)&&Time.timeScale==1&&!stopbullet)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        }
    

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy")) // "Enemy" タグのオブジェクトにぶつかったら
        {
          stopbullet = true;
            MenuUI = true;
            scoreBoard.ShowScoreBoard(Score.score);
            sss.SetActive(false);
            

        }




    }
   


}