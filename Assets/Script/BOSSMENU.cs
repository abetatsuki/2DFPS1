using UnityEngine;
using TMPro; // TextMeshProを使う場合
using UnityEngine.SceneManagement;
public class BOSSMENU : MonoBehaviour
{
    public TMP_Text[] menuItems; // InspectorでTextを配列でセット
    private int selectedIndex = 0;

    void Update()
    {
        // 上キー
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedIndex--;
            if (selectedIndex < 0) selectedIndex = menuItems.Length - 1;
            UpdateMenu();
        }

        // 下キー
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex++;
            if (selectedIndex >= menuItems.Length) selectedIndex = 0;
            UpdateMenu();
        }

        // 決定キー
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log(menuItems[selectedIndex].text + " が選択されました");

            if (menuItems[selectedIndex].text == "END")
            {
                Application.Quit(); // ビルド時にアプリ終了
            }
            if (menuItems[selectedIndex].text == "START")
            {
                SceneManager.LoadScene("SampleScene");
            }
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
                menuItems[i].color = Color.white; // 未選択
        }
    }
}
