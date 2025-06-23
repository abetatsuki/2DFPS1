using UnityEngine;
using TMPro;

public class TextDisplayFor3Seconds : MonoBehaviour
{
    public TMP_Text targetText; // Inspectorでセット

    private float displayDuration = 3f;

    void Start()
    {
        targetText.enabled = true;   // 表示
        Invoke(nameof(HideText), displayDuration);  // 3秒後に非表示
    }

    void HideText()
    {
        targetText.enabled = false;  // 非表示
    }
}
