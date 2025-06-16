using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic; // 追加

public class PauseAndBossMenuController : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject gameUI;
    public TMP_Text[] menuItems;
    private int selectedIndex = 0;
    private bool isPaused = false;
    public AudioClip SelectSound;
    AudioSource audioSource;

    void Start()
    {
        menuUI.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
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
            List<int> visibleIndexes = GetVisibleMenuItemIndexes();

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                audioSource.PlayOneShot(SelectSound);
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = visibleIndexes.Count - 1;
                UpdateMenu(visibleIndexes);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                audioSource.PlayOneShot(SelectSound);
                selectedIndex++;
                if (selectedIndex >= visibleIndexes.Count) selectedIndex = 0;
                UpdateMenu(visibleIndexes);
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                audioSource.PlayOneShot(SelectSound);
                ExecuteMenuItem(visibleIndexes);
            }
        }
    }

    void Pause()
    {
        menuUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        selectedIndex = 0;
        UpdateMenu(GetVisibleMenuItemIndexes());
    }

    public void Resume()
    {
        menuUI.SetActive(false);
        gameUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void ExecuteMenuItem(List<int> visibleIndexes)
    {
        int realIndex = visibleIndexes[selectedIndex];
        string selectedItem = menuItems[realIndex].text;

        Debug.Log(selectedItem + " が選択されました");

        if (selectedItem == "START")
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("SampleScene");
        }
        else if (selectedItem == "END")
        {
            Debug.Log("ゲームを終了します");
            Application.Quit();
        }
        else if (selectedItem == "OPTION")
        {
            menuUI.SetActive(false);
            gameUI.SetActive(true);
        }
    }

    void UpdateMenu(List<int> visibleIndexes)
    {
        for (int i = 0; i < menuItems.Length; i++)
        {
            menuItems[i].color = Color.white; // 全部白に戻す
        }

        if (visibleIndexes.Count > 0)
        {
            int realIndex = visibleIndexes[selectedIndex];
            menuItems[realIndex].color = Color.yellow; // 選択中だけ黄色
        }
    }

    List<int> GetVisibleMenuItemIndexes()
    {
        List<int> visibleIndexes = new List<int>();
        for (int i = 0; i < menuItems.Length; i++)
        {
            if (menuItems[i].gameObject.activeSelf && !string.IsNullOrWhiteSpace(menuItems[i].text))
            {
                visibleIndexes.Add(i);
            }
        }
        return visibleIndexes;
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
