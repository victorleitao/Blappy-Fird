using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    private int score;
    private int highestScore = 0;

    private void Start()
    {
        highestScore = PlayerPrefs.GetInt("HighScore");
    }

    private void FixedUpdate()
    {
        score = GameManager.Instance.playerScore;
        scoreText.text = score.ToString();

        if (score > highestScore)
        {
            highestScore = score;
            PlayerPrefs.SetInt("HighScore", highestScore);
        }
        highScoreText.text = "Highest Score: " + highestScore;
    }
}
