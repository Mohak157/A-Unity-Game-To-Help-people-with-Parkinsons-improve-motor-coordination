using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public TMP_Text highScoreText;
    public ScoreManager scoreManager;
    public int currentScore;
    void Update()
    {
        int currentScore = scoreManager.GetScore();
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text="HIGH SCORE :"+((int)highScore).ToString();

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }


    }
    public int GethighScore()
    {
        return currentScore;
    }
}