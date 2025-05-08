using UnityEngine;
using UnityEngine.UI;

public class TampilScoreGameOver : MonoBehaviour
{
    public Text ScoreText;

    void Start()
    {
        ScoreText.text = "Skor Akhir: " + Data.score.ToString();
    }
}
