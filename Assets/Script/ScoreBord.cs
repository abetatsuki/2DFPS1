using UnityEngine;
using TMPro;

public class ScoreBord : MonoBehaviour
{
    public GameObject scorePanel;     // スコアボードのパネル
    public TextMeshProUGUI FinalscoreText; // スコア表示用テキスト
    private int finalScore;           // 最終スコア

    // ゲーム終了時に呼ばれる
    public void ShowScoreBoard(int score)
    {
        finalScore = score;
        FinalscoreText.text = "Your Score: " + finalScore.ToString();
        scorePanel.SetActive(true);
    }
}
