using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text currentScore;
    public Text finalScore;

    public void SetGameOver()
    {
        gameOverScreen.SetActive(true);
        finalScore.text = "Score: " + currentScore.text;
    }
}
