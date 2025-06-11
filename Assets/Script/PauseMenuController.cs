using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject menuUI; // メニューUI全体のGameObject（Canvasなど）

    private bool isPaused = false;

    void Start()
    {
        menuUI.SetActive(false); // 最初は非表示
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    void Pause()
    {
        menuUI.SetActive(true);      // メニュー表示
        Time.timeScale = 0f;         // ゲーム停止
        isPaused = true;
        
    }

    public void Resume()
    {
        menuUI.SetActive(false);     // メニュー非表示
        Time.timeScale = 1f;         // ゲーム再開
        isPaused = false;
        
    }

    public void QuitGame()
    {
        Debug.Log("ゲームを終了します");
        Application.Quit();
    }
}
