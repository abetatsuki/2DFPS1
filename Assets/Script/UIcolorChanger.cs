using TMPro;
using UnityEngine;

public class UIcolorChanger : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // 3DÇÃèÍçá TextMeshPro Ç…Ç∑ÇÈ

    void Update()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        textMeshPro.color = randomColor;
    }
}