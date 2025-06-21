using UnityEngine;
using TMPro; // TextMeshPro用
using UnityEngine.SceneManagement;

public class PauseAndBossMenuController : MonoBehaviour
{
    public GameObject menuUI;          // ポーズメニュー全体(Canvas)
    public TMP_Text[] menuItems;       // TextMeshProで表示するメニュー項目
    private int selectedIndex = 0;
    private bool isPaused = false;
    public AudioClip SelectSound;
    AudioSource audioSource;
    string scene;
    void Start()
    {
        menuUI.SetActive(false); // 最初は非表示
        audioSource = GetComponent<AudioSource>(); // 追加！！
    }

    void Update()
    {
         scene = SceneManager.GetActiveScene().name;

        // ESCキーでポーズ
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (isPaused)
                Resume();
            else
                Pause();
            audioSource.PlayOneShot(SelectSound);
        }

        if (isPaused)
        {
            // 上キー
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                audioSource.PlayOneShot(SelectSound);
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = menuItems.Length - 1;
                UpdateMenu();
            }

            // 下キー
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                audioSource.PlayOneShot(SelectSound);
                selectedIndex++;
                if (selectedIndex >= menuItems.Length) selectedIndex = 0;
                UpdateMenu();
            }

            // 決定キー
            if (Input.GetKeyDown(KeyCode.Return))
            {
                audioSource.PlayOneShot(SelectSound);
                ExecuteMenuItem();
            }
        }
    }

    void Pause()
    {
        menuUI.SetActive(true);   // メニュー表示
        Time.timeScale = 0f;      // ゲーム停止
        isPaused = true;
        UpdateMenu();             // 最初の選択項目ハイライト
    }

    public void Resume()
    {
        menuUI.SetActive(false);  // メニュー非表示
        Time.timeScale = 1f;      // ゲーム再開
        isPaused = false;
    }

    void ExecuteMenuItem()
    {
        string selectedItem = menuItems[selectedIndex].text;

        Debug.Log(selectedItem + " が選択されました");

        if (selectedItem == "START")
        {
            Time.timeScale = 1f; // 必ずゲーム速度リセット
            if (scene  != "SampleScene")
            {
                SceneManager.LoadScene("SampleScene"); // シーン遷移
            }
            
        }
        else if (selectedItem == "END")
        {
            Debug.Log("ゲームを終了します");
            Application.Quit();
        }
    }

    void UpdateMenu()
    {
        // 選択中の項目だけ色変更
        for (int i = 0; i < menuItems.Length; i++)
        {
            if (i == selectedIndex)
                menuItems[i].color = Color.yellow; // 選択中
            else
                menuItems[i].color = Color.white;  // 未選択
        }
    }
    public void PlaySound(AudioClip clip, Vector3 position)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, position);
            Debug.Log("Sound Played: " + clip.name);
        }
    }
}