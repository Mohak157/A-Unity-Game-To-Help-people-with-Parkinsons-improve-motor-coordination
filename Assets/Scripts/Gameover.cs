using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public GameObject gameOverPanel;
    public HighScoreManager highScoreManager;

    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver && GameObject.FindGameObjectWithTag("Player") == null)
        {
            isGameOver = true;

            gameOverPanel.SetActive(true);
            highScoreManager.GethighScore();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void goback()
    {
        SceneManager.LoadSceneAsync(0);
    }
}