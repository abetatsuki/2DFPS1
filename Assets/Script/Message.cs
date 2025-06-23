using UnityEngine;
using TMPro;
using System.Collections;

public class TextDisplayFor3Seconds : MonoBehaviour
{
    public TMP_Text targetText; // Inspectorでセット

    private float displayDuration = 1f;
    private float changeInterval = 0.1f; // 色を変える間隔（秒）

    void Start()
    {
        targetText.enabled = true;   // 表示
        StartCoroutine(ChangeColorRoutine());
    }

    IEnumerator ChangeColorRoutine()
    {
        float elapsed = 0f;
        while (elapsed < displayDuration)
        {
            // ランダムな色を設定（RGBのみ）
            targetText.color = new Color(Random.value, Random.value, Random.value, 1f);

            yield return new WaitForSeconds(changeInterval);
            elapsed += changeInterval;
        }

        HideText();  // ループ終了後に1回だけ呼ぶ
    }

    void HideText()
    {
        targetText.enabled = false;  // 非表示
    }
}
